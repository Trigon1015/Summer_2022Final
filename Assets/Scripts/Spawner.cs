using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner instance;

    public GameObject playerGO;

    public float spawnRange;
    public float minSpawnFrequency;
    public float maxSpawnFrequency;

    public int largeChests = 4;
    public int smallChests = 7;

    public int minSpawnAmount;
    public int maxSpawnAmount;
    // public int enemyCount = 0;
    // public int maxEnemies = 50;

    public GameObject[] enemyPrefabs;
    public GameObject sChestPrefab;
    public GameObject lChestPrefab;
    public LayerMask whatIsGround;

    public static Spawner FindInstance()
    {
        return instance;
    }
    private void Awake()
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
        playerGO = GameObject.FindGameObjectWithTag("Player");
        SpawnSmallChests();
        SpawnLargeChests();
        Invoke("Spawn", minSpawnFrequency);
    }

    //helper functions
    private Vector2 FindSpawn(float range, Vector3 position)
    {
        Bounds bounds = new Bounds(position, new Vector2(range * 2, range * 2));
        Vector2 _v = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
        return _v;
    }

    private void SpawnEnemy(bool inHorde, int index, Vector2 vector)
    {
        if (inHorde)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector2 _v = FindSpawn(1f, vector);
            RaycastHit2D ground = Physics2D.Raycast(_v, Vector2.down, 5f, whatIsGround);
            RaycastHit2D air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, enemyPrefabs[enemyIndex].GetComponent<BoxCollider2D>().size.y, whatIsGround);

            while (!ground || air)
            {
                _v = FindSpawn(1f, vector);
                ground = Physics2D.Raycast(_v, Vector2.down, 5f, whatIsGround);
                air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, enemyPrefabs[enemyIndex].GetComponent<BoxCollider2D>().size.y + 1f, whatIsGround);
            }

            if (ground && !air)
            {
                //make enemy
                Vector2 spawnLocation = new Vector2(ground.point.x, ground.point.y + enemyPrefabs[enemyIndex].GetComponent<BoxCollider2D>().size.y / 2);
                SpawnEnemy(false, enemyIndex, spawnLocation);
            }
        }
        else
        {
            Instantiate(enemyPrefabs[index], vector, Quaternion.identity);
            // enemyCount++;
        }
    }

    private void Spawn()
    {
        float randomTime = Random.Range(minSpawnFrequency, maxSpawnFrequency);
        bool functionCall = false;

        // if (enemyCount < maxEnemies)
        // {
        //spawn enemy
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector2 _v = FindSpawn(spawnRange, playerGO.transform.position);
        RaycastHit2D ground = Physics2D.Raycast(_v, Vector2.down, 5f, whatIsGround);
        RaycastHit2D air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, enemyPrefabs[enemyIndex].GetComponent<BoxCollider2D>().size.y, whatIsGround);

        if (ground && !air)
        {
            //make enemy
            Vector2 spawnLocation = new Vector2(ground.point.x, ground.point.y + enemyPrefabs[enemyIndex].GetComponent<BoxCollider2D>().size.y / 2);
            SpawnEnemy(false, enemyIndex, spawnLocation);

            //create horde
            int amount = Random.Range(minSpawnAmount, maxSpawnAmount);
            for (int i = 0; i < amount; i++)
            {
                SpawnEnemy(true, enemyIndex, spawnLocation);
            }
        }
        else
        {
            functionCall = true;
            Invoke("Spawn", 0.5f);
        }
        // }

        if (functionCall == false)
        {
            Invoke("Spawn", randomTime);
        }
    }

    private void SpawnSmallChests()
    {
        int chestNum = smallChests;
        Bounds bounds = gameObject.transform.Find("SpawnBound").GetComponent<BoxCollider2D>().bounds;
        for (int i = 0; i < chestNum; i++)
        {
            Vector2 _v = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
            RaycastHit2D ground = Physics2D.Raycast(_v, Vector2.down, Mathf.Infinity, whatIsGround);
            RaycastHit2D air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, sChestPrefab.transform.Find("small_chest").GetComponent<BoxCollider2D>().size.y, whatIsGround);

            while (!ground || air)
            {
                _v = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                ground = Physics2D.Raycast(_v, Vector2.down, Mathf.Infinity, whatIsGround);
                air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, sChestPrefab.transform.Find("small_chest").GetComponent<BoxCollider2D>().size.y, whatIsGround);
            }

            if (ground && !air)
            {
                Vector2 spawnLocation = new Vector2(ground.point.x, ground.point.y);
                Instantiate(sChestPrefab, spawnLocation, Quaternion.identity);
            }
        }
    }

    private void SpawnLargeChests()
    {
        int chestNum = largeChests;
        Bounds bounds = gameObject.transform.Find("SpawnBound").GetComponent<BoxCollider2D>().bounds;
        for (int i = 0; i < chestNum; i++)
        {
            Vector2 _v = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
            RaycastHit2D ground = Physics2D.Raycast(_v, Vector2.down, Mathf.Infinity, whatIsGround);
            RaycastHit2D air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, lChestPrefab.transform.Find("large_chest").GetComponent<BoxCollider2D>().size.y, whatIsGround);

            while (!ground || air)
            {
                _v = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
                ground = Physics2D.Raycast(_v, Vector2.down, Mathf.Infinity, whatIsGround);
                air = Physics2D.Raycast(new Vector2(ground.point.x, ground.point.y), Vector2.up, lChestPrefab.transform.Find("large_chest").GetComponent<BoxCollider2D>().size.y, whatIsGround);
            }

            if (ground && !air)
            {
                Vector2 spawnLocation = new Vector2(ground.point.x, ground.point.y);
                Instantiate(lChestPrefab, spawnLocation, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerGO.transform.position, new Vector2(spawnRange * 2, spawnRange * 2));
    }

}
