using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    private GameObject[] enemies;   
    private float disToPlayer = 1000f;
    private PlayerController player;
    private Transform target;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) {
            float dist = Vector2.Distance(enemy.transform.position, player.transform.position);
            if (dist < disToPlayer)
            {
                disToPlayer = dist;
                target = enemy.transform;
            }
        }

        // get the angle
        Vector3 norTar = (target.transform.position-transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y,norTar.x)*Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion ();
        rotation.eulerAngles = new Vector3(0,0,angle-90);
        transform.rotation = rotation;
    }
}
