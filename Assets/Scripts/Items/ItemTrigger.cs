using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public string _name;
    private bool collected = false;

    public float min = 2f;
    public float max = 3f;
    // Use this for initialization
    void Start()
    {

        min = transform.position.y;
        max = transform.position.y + 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 0.25f, max - min) + min, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!collected)
            {
                AudioManager.instance.PlaySFX(20);
                ItemManager.FindInstance().AddItem(_name);
                collected = true;
            }
            Invoke("DeleteItem", 0.25f);
        }
    }

    private void DeleteItem()
    {
        GameManager.FindInstance().items++;
        Destroy(gameObject);
    }
}
