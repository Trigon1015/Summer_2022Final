using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeHUD : MonoBehaviour
{
    private AudioSource[] VolumeCtrl;
    [SerializeField] private TextMeshProUGUI VolumePrcnt;
    private int Volume = 100;

    private void Start()
    {
        VolumeCtrl = FindObjectsOfType<AudioSource>();
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
