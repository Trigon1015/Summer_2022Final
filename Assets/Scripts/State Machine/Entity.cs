using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemies inherit this
public class Entity : MonoBehaviour
{
    public FSM stateMachine;
    public D_Entity entityData;

    public int facingDirection { get; set; }

    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject entity { get; private set; }
    public AnimationToStateMachine atsm { get; private set; }

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    // [SerializeField]
    // private Transform backCheck;
    [SerializeField]
    private Transform playerCheck;

    private Vector2 velocityWorkspace; //temp variable for any vector2
    public GameObject playerGO;
    public GameObject coinPrefab;
    public GameObject sCoinPrefab;
    public GameObject expPrefab;

    private GameObject healthBar;

    public AudioSource audioSource;

    public bool stunned = false;
    public bool knockback = false;

    private float flipCooldown = 0.2f;
    private float lastFlipTime = -0.2f;

    public float spriteHeight;
    public float spriteWidth;

    public int currHealth;

    public float previousKnockbackVelocity;
    public float previousStunVelocity;

    public virtual void Start()
    {
        facingDirection = 1;

        entity = this.gameObject;
        rb = entity.GetComponent<Rigidbody2D>();
        anim = entity.GetComponent<Animator>();
        atsm = entity.GetComponent<AnimationToStateMachine>();

        stateMachine = new FSM();
        playerGO = GameObject.FindGameObjectWithTag("Player");
        healthBar = gameObject.transform.Find("HealthBar").gameObject;
        spriteHeight = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        spriteWidth = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        currHealth = entityData.startingHealth;
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    //set velocity of enemy
    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }


    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, entity.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckMinAggroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.minAggroRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckMaxAggroRange()
    {
        return Physics2D.OverlapCircle(playerCheck.position, entityData.maxAggroRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInAttackRange()
    {
        return Physics2D.Raycast(playerCheck.position, playerGO.transform.right, entityData.attackRange, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerIsGrounded()
    {
        return playerGO.GetComponent<PlayerController>().Grounded;
    }

    public virtual void Flip()
    {
        if (Time.time >= lastFlipTime + flipCooldown)
        {
            lastFlipTime = Time.time;
            facingDirection *= -1;
            entity.transform.Rotate(0f, 180f, 0f);
            healthBar.transform.Rotate(0f, 180f, 0f);
        }
    }
    public virtual void Flip(bool ignoreCD)
    {
        lastFlipTime = Time.time;
        facingDirection *= -1;
        entity.transform.Rotate(0f, 180f, 0f);
        healthBar.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void SetPosition(Vector2 position)
    {
        entity.transform.position = position;
    }

    public virtual void TakeDamage(int damage)
    {
        //take damage
        currHealth -= damage;
        healthBar.GetComponent<HealthBar>().LowerHealth(currHealth, entityData.startingHealth);

        if (currHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Knockback(Vector2 direction)
    {
        // if (!stunned || !knockback)
        // {
        previousKnockbackVelocity = rb.velocity.x;
        rb.AddForce(direction * 2, ForceMode2D.Impulse);
        knockback = true;

        // if (!stunned)
        // {
        Invoke("ResetKnockback", 0.25f);
        // }
        // }
    }

    public virtual void Stun()
    {
        previousStunVelocity = rb.velocity.x;
        SetVelocity(0f);
        gameObject.transform.Find("Stun").gameObject.SetActive(true);
        stunned = true;

        // if (!knockback)
        // {
        Invoke("ResetStun", 0.5f);
        // }
    }

    public virtual void ResetStun()
    {
        stunned = false;
        gameObject.transform.Find("Stun").gameObject.SetActive(false);

        if (!knockback)
        {
            if (facingDirection == 1)
            {
                SetVelocity(previousStunVelocity);
            }
            else
            {
                SetVelocity(-previousStunVelocity);
            }
        }
    }

    public virtual void ResetKnockback()
    {
        knockback = false;

        if (!stunned || previousKnockbackVelocity == 0f)
        {
            if (facingDirection == 1)
            {
                SetVelocity(previousKnockbackVelocity);
            }
            else
            {
                SetVelocity(-previousKnockbackVelocity);
            }
        }
    }

    public virtual void Die()
    { }

    public virtual void StartDeath()
    {
        gameObject.layer = LayerMask.NameToLayer("DeadEnemy");
        gameObject.tag = "DeadEnemy";
        GameManager.FindInstance().kills++;
        // GameManager.FindInstance().AddDeadEnemy(gameObject);
    }

    public virtual void Destroy()
    {
        // FindObjectOfType<ResultScreen>().killCount++; //TODO: add back
        Destroy(gameObject.GetComponent<AnimationToStateMachine>());
        Destroy(gameObject.GetComponent<Animator>());

        SpawnExp();
        SpawnCoins();
        gameObject.GetComponent<DestroyScript>().destroy = true;
        Destroy(this);
    }

    public virtual void OnDrawGizmos()
    {
        //Vector2 originBack = new Vector2(ledgeCheck.position.x - gameObject.GetComponent<SpriteRenderer>().sprite.rect.width / 2, ledgeCheck.position.y);
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
        // Gizmos.DrawLine(backCheck.position, backCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));

        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(entity.transform.right * entityData.attackRange), 0.1f);
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(entity.transform.right * entityData.minAggroRange), 0.1f);
        // Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(entity.transform.right * entityData.maxAggroRange), 0.1f);
    }

    public void SpawnCoins()
    {
        int coins = entityData.coins / 5;
        //big coins
        for (int i = 0; i < coins; i++)
        {
            Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity);
        }

        int sCoins = entityData.coins % 5;
        //small coins
        for (int i = 0; i < sCoins; i++)
        {
            Instantiate(sCoinPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void SpawnExp()
    {
        for (int i = 0; i < entityData.exp; i += 10)
        {
            Instantiate(expPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
