using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Vector3 localScale;
    public GameObject healthBar;
    public int healthScale;

    private void Start()
    {
        // healthBar = transform.Find("Health").gameObject;
        localScale = healthBar.transform.localScale;
    }

    public void LowerHealth(int currHealth, int totalHealth)
    {
        //healthbar active
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }

        //lower healthbar
        float percentage = (float)currHealth / totalHealth;
        if (percentage <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            healthBar.transform.localScale = new Vector3(percentage * healthScale, 1f, localScale.z);
        }
    }
}
