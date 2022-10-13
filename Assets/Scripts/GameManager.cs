using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public float health = 150;
    public float maxhp = 150;
    public int exp = 0;
    public GameObject damageNumberPrefab;

    // private Queue deadEnemies;

    //for DeathUI stats
    public int coins = 0; //gold
    public int kills = 0;
    public int bossKill = 0;
    public int items = 0;
    public int purchases = 0;
    public string killedBy = "The Planet";
    // get time and level from hud or something

    public static GameManager FindInstance()
    {
        return instance; //that's just a singletone as the region says
    }

    private void Awake() //this happens before the game even starts and it's a part of the singletone
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }

    private void Start()
    {
        InvokeRepeating("RegenHealth", 2f, 2f);
    }

    private void RegenHealth()
    {
        int regen = 1;
        if (health < maxhp)
        {
            if (health + regen > maxhp)
            {
                health = maxhp;
            }
            else
            {
                health += regen;
            }
        }
    }

    public void SpawnDamageNumber(int damage, RaycastHit2D hitInfo, bool crit)
    {
        if (crit)
        {
            int count = 0;
            while (damage > 0)
            {
                GameObject num = Instantiate(damageNumberPrefab, new Vector2(hitInfo.point.x + 0.1f * count, hitInfo.point.y), Quaternion.identity);
                num.GetComponent<DamageNumber>().damage = damage % 10;
                num.GetComponent<DamageNumber>().crit = true;
                damage = damage / 10;
                count--;
            }
        }
        else
        {
            int count = 0;
            while (damage > 0)
            {
                GameObject num = Instantiate(damageNumberPrefab, new Vector2(hitInfo.point.x + 0.1f * count, hitInfo.point.y), Quaternion.identity);
                num.GetComponent<DamageNumber>().damage = damage % 10;
                num.GetComponent<DamageNumber>().crit = false;
                damage = damage / 10;
                count--;
            }
        }
    }

    public void SpawnDamageNumber(int damage, Collider2D collider)
    {
        int count = 0;
        while (damage > 0)
        {
            GameObject num = Instantiate(damageNumberPrefab,
                new Vector2(
                collider.gameObject.transform.position.x + 0.1f * count,
                collider.gameObject.transform.position.y + 0.1f + collider.gameObject.GetComponent<BoxCollider2D>().size.y / 2),
                Quaternion.identity);
            num.GetComponent<DamageNumber>().damage = damage % 10;
            damage = damage / 10;
            count--;
        }
    }
}
