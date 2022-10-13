using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject sOpt;
    [SerializeField] private GameObject sCred;
    [SerializeField] private GameObject sOptTxt;
    [SerializeField] private GameObject sCtrl;
    [SerializeField] private GameObject sAV;
    [SerializeField] private GameObject sQuit;

    private AudioSource[] VolumeCtrl;
    [SerializeField] private TextMeshProUGUI VolumePrcnt;
    private int Volume = 100;
    

    private void Start()
    {
        AudioManager.instance.PlayTitleScreenMusic();
        VolumeCtrl = FindObjectsOfType<AudioSource>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("CharacterSelect");
        AudioManager.instance.titleScreenMusic.Stop();
        Debug.Log("PRESSED");
    }

    //title screen
    public void OpenOpt()
    {
        sOpt.SetActive(true);
    }

    public void CloseOpt()
    {
        sOpt.SetActive(false);
    }

    public void OpenCred()
    {
        sCred.SetActive(true);
    }

    public void CloseCred()
    {
        sCred.SetActive(false);
    }

    public void OpenQuit()
    {
        sQuit.SetActive(true);
    }

    public void CloseQuit()
    {
        sQuit.SetActive(false);
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

    public void ToggleVolume()
    {
        if (Volume < 100)
        {
            Volume += 10;
        }
        else
        {
            Volume = 0;
        }
        VolumePrcnt.text = Volume + "%";

        foreach(AudioSource source in VolumeCtrl)
        {
            source.volume = (Volume * 1.0f)/100.0f;
        }
    }
}
