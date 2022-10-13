using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPauseToggl : MonoBehaviour
{
    [SerializeField] private GameObject sPause;
    [SerializeField] private GameObject sOptTxt;
    [SerializeField] private GameObject sCtrl;
    [SerializeField] private GameObject sAV;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sPause.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        sPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        // Debug.Log("asdf");
        sPause.SetActive(false);
        Time.timeScale = 1f;
    }

    // options/
    public void OpenCtrl()
    {
        sCtrl.SetActive(true);
        sOptTxt.SetActive(false);
    }

    public void CloseCtrl()
    {
        sCtrl.SetActive(false);
        sOptTxt.SetActive(true);
    }

    public void OpenAV()
    {
        sAV.SetActive(true);
        sOptTxt.SetActive(false);
    }

    public void CloseAV()
    {
        sAV.SetActive(false);
        sOptTxt.SetActive(true);
    }
}
