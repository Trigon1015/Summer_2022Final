using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public Dictionary<string, Item> itemsData; //name, item object
    public Dictionary<string, int> collectedItems; //name, quantity

    public GameObject[] itemPrefabs;

    public GameObject efx_feather;
    public GameObject prefabUI;
    // private GameObject itemUI;
    private GameObject itemTitleUI;
    private GameObject itemDescUI;

    public static ItemManager FindInstance()
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
        collectedItems = new Dictionary<string, int>();
        itemsData = new Dictionary<string, Item>();
        itemsData.Add("feather", new Feather());
        itemsData.Add("lens", new Lens());
        itemsData.Add("syringe", new Syringe());

        //TODO: add all created items to itemsData
        prefabUI = GameObject.FindGameObjectWithTag("ItemUI");
        itemTitleUI = prefabUI.transform.Find("title").gameObject;
        itemDescUI = prefabUI.transform.Find("description").gameObject;
        itemTitleUI.GetComponent<TextMeshProUGUI>().color = Color.clear;
        itemDescUI.GetComponent<TextMeshProUGUI>().color = Color.clear;
    }

    public void AddItem(string item)
    {
        if (collectedItems.ContainsKey(item))
        {
            collectedItems[item]++;
        }
        else
        {
            collectedItems.Add(item, 1);
        }

        itemTitleUI.GetComponent<TextMeshProUGUI>().SetText(GetItem(item).fullName);
        itemDescUI.GetComponent<TextMeshProUGUI>().SetText(GetItem(item).description);
        itemTitleUI.GetComponent<TextMeshProUGUI>().color = Color.white;
        itemDescUI.GetComponent<TextMeshProUGUI>().color = Color.white;
        StartCoroutine(Fade(1f));
    }

    public IEnumerator Fade(float delay = 0f)
    {
        //wait
        if (delay != 0)
            yield return new WaitForSeconds(delay);

        float duration = 2f; //Fade out over 2 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            itemTitleUI.GetComponent<TextMeshProUGUI>().color = new Color(itemTitleUI.GetComponent<TextMeshProUGUI>().color.r, itemTitleUI.GetComponent<TextMeshProUGUI>().color.g, itemTitleUI.GetComponent<TextMeshProUGUI>().color.b, alpha);
            itemDescUI.GetComponent<TextMeshProUGUI>().color = new Color(itemDescUI.GetComponent<TextMeshProUGUI>().color.r, itemDescUI.GetComponent<TextMeshProUGUI>().color.g, itemDescUI.GetComponent<TextMeshProUGUI>().color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    //for chests
    public GameObject RandomItem()
    {
        int i = UnityEngine.Random.Range(0, itemPrefabs.Length);
        return itemPrefabs[i];
    }

    public Item GetItem(string item)
    {
        return itemsData[item];
    }

    //returns the number of items, 0 if none
    public int ItemCount(string item)
    {
        if (collectedItems.ContainsKey(item))
        {
            return collectedItems[item];
        }
        else
        {
            return 0;
        }
    }

    public Feather GetFeather()
    {
        return (Feather)itemsData["feather"];
    }


    public bool HasItem(string item)
    {
        if (collectedItems.ContainsKey(item))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
