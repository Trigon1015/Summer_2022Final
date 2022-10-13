using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool floatToPlayer = false;
    private Vector2 _direction;
    public GameObject playerGO;
    public Rigidbody2D _rb;
    public int value;
    private float timeStamp;

    private void Start()
    {
        Vector2 velocity = new Vector2(Random.Range(0, 2) * 2 - 1, 1f);
        gameObject.GetComponent<Rigidbody2D>().GetComponent<Rigidbody2D>().velocity = velocity;

        Invoke("FloatToPlayer", 2.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(18);
            GameManager.FindInstance().coins += value;
            Destroy(gameObject);
        }
    }

    private void FloatToPlayer()
    {
        floatToPlayer = true;
        timeStamp = Time.time;
        playerGO = GameObject.FindWithTag("Player");
        Destroy(gameObject.transform.Find("collider").gameObject);
    }

    private void Update()
    {
        if (floatToPlayer)
        {
            _direction = -(transform.position - playerGO.transform.position).normalized;
            _rb.velocity = new Vector2(_direction.x, _direction.y) * 5f * (Time.time / timeStamp);
        }
    }
}
