using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    public int smallCost = 25;
    public int largeCost = 50;
    public int cost;
    // public GameObject item;

    private bool canOpen;
    private Animator anim;
    public bool large;

    public GameObject itemPrefab;
    private bool opened = false;

    public GameObject[] texts;

    private void Start()
    {
        if (large)
        {
            cost = largeCost;
        }
        else
        {
            cost = smallCost;
        }

        anim = gameObject.GetComponent<Animator>();
        itemPrefab = ItemManager.FindInstance().RandomItem();
    }

    private void Update()
    {
        if (!opened && canOpen && Input.GetKeyDown(KeyCode.E) && GameManager.FindInstance().coins >= cost)
        {
            //audio
            AudioManager.instance.PlaySFX(11);
            opened = true;
            GameManager.FindInstance().coins -= cost;
            anim.SetBool("open", true);
            GameManager.FindInstance().purchases++;
            foreach (GameObject text in texts)
                text.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }

    //animation event funciton
    public void SpawnItem()
    {
        Instantiate(itemPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.25f), Quaternion.identity);
    }
}
