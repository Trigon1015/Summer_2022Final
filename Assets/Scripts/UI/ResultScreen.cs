using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelTxt, timeTxt, killTxt, killedbyTxt, BossTxt, itemTxt, goldTxt, purchaseTxt, TitleTxt;

    private void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        // Time.timeScale = 0;
        levelTxt.text = 1 + GameManager.FindInstance().exp / 100 + "";
        timeTxt.text = FindObjectOfType<Timer>().timeText.text;
        goldTxt.text = GameManager.FindInstance().coins + "";
        killTxt.text = GameManager.FindInstance().kills + "";
        BossTxt.text = GameManager.FindInstance().bossKill + "";
        itemTxt.text = GameManager.FindInstance().items + "";
        purchaseTxt.text = GameManager.FindInstance().purchases + "";
        killedbyTxt.text = "Killed by: " + GameManager.FindInstance().killedBy;
    }

    public void showWinScreen()
    {
        TitleTxt.text = "Win, Thank you for playing the demo!";

    }

    public void showLossScreen()
    {
    }

    public void goback()
    {
        Time.timeScale = 1f;
        AudioManager.instance.PlayTitleScreenMusic();
        Destroy(GameManager.FindInstance().gameObject);
        Destroy(Spawner.FindInstance().gameObject);
        Destroy(ItemManager.FindInstance().gameObject);
        SceneManager.LoadScene(0);
    }

    public void tryagain()
    {
        Time.timeScale = 1f;
        AudioManager.instance.PlayLevelMusic();
        Destroy(GameManager.FindInstance().gameObject);
        Destroy(Spawner.FindInstance().gameObject);
        Destroy(ItemManager.FindInstance().gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
