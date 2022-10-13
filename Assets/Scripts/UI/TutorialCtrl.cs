using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCtrl : MonoBehaviour
{
    [SerializeField] private float dist;
    [SerializeField] private GameObject UI;
    void Update()
    {
        if (Vector2.Distance(FindObjectOfType<PlayerController>().transform.position, transform.position) > dist)
            UI.SetActive(false);
    }
}
