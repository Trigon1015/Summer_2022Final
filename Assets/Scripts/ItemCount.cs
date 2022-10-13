using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour
{
    public string _name;
    private int count = 0;

    private void Update()
    {
        if (ItemManager.FindInstance().ItemCount(_name) != count)
        {
            count = ItemManager.FindInstance().ItemCount(_name);
            gameObject.transform.Find("txt").GetComponent<TextMeshProUGUI>().SetText("x" + count);
        }
    }

}
