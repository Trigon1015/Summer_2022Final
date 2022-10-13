using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
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

    public AudioSource titleScreenMusic, levelMusic, bossMusic;
    public AudioSource[] sfx;

    public void PlayTitleScreenMusic()
    {

        levelMusic.Stop();
        bossMusic.Stop();
        titleScreenMusic.Play();

    }

    public void PlayLevelMusic()
    {
        if (!levelMusic.isPlaying)
        {

            titleScreenMusic.Stop();
            bossMusic.Stop();
            levelMusic.Play();

        }
    }

    public void PlayBossMusic()
    {
        if (!bossMusic.isPlaying)
        {
            levelMusic.Stop();
            bossMusic.Play();
        }


    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();
        sfx[sfxToPlay].Play();
    }
}
