using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDcontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cointxt, difftxt, missiontxt, lvltxt, hptxt, CDtxt2, CDtxt3, CDtxt4;
    [SerializeField] private GameObject immunebar, abilityCD2, abilityCD3, abilityCD4, resultScreen;
    [SerializeField] private RawImage damagebar, hpbar, expbar;
    [SerializeField] private RectTransform diffMask;

    private float[] diffThreshold = new float[] { 13.82f, 27.57f, 41.42f, 55.36f, 69.49f, 83.43f, 97.56f, 111.69f };
    private string[] diffTexts = new string[] { "Very Easy", "Esay", "Medium", "Hard", "Very Hard", "Insane", "Impossible", "I SEE YOU", "I'M COMING FOR YOU" };
    private PlayerController player;
    private void Start()
    {
        immunebar.SetActive(false);
        player = FindObjectOfType<PlayerController>();
        diffMask.sizeDelta = new Vector2(diffMask.rect.width, 0);
    }
    private void Update()
    {
        //Coin
        cointxt.text = GameManager.FindInstance().coins + "";

        //health bar
        hptxt.text = Mathf.Max(0, (int)GameManager.FindInstance().health) + "/" + Mathf.Max((int)GameManager.FindInstance().maxhp);
        hpbar.transform.localScale = new Vector3(Mathf.Max(0, GameManager.FindInstance().health) / GameManager.FindInstance().maxhp, 1, 1);
        if (damagebar.transform.localScale.x - hpbar.transform.localScale.x <= 0.01)
        {
            damagebar.transform.localScale = hpbar.transform.localScale;
        }
        else
        {
            damagebar.transform.localScale = Vector3.Lerp(damagebar.transform.localScale, hpbar.transform.localScale, 0.02f);
        }
        if (FindObjectOfType<PlayerController>().rolling)
        {
            immunebar.SetActive(true);
        }
        else
        {
            immunebar.SetActive(false);
        }


        //Ex bar
        lvltxt.text = 1 + GameManager.FindInstance().exp / 100 + "";
        expbar.transform.localScale = new Vector3((Mathf.Max(0, GameManager.FindInstance().exp) % 100.0f) / 100.0f, 1, 1);

        //diff bar
        for (int i = 0; i < diffThreshold.Length; i++)
            if (diffMask.rect.height >= diffThreshold[i])
                difftxt.text = diffTexts[i + 1];
        diffMask.sizeDelta = new Vector2(diffMask.rect.width, FindObjectOfType<Timer>().timeRemaining / 5.5f);

        if (player.Shoot2Counter != 0 && player.Shoot2Counter < player.shoot2CD)
        {
            abilityCD2.SetActive(true);
            CDtxt2.text = (int)(player.Shoot2Counter) + "";
        }
        else
        {
            abilityCD2.SetActive(false);
        }
        if (player.Shoot3Counter != 0 && player.Shoot3Counter < player.shoot3CD)
        {
            abilityCD3.SetActive(true);
            CDtxt3.text = (int)(player.Shoot3Counter) + "";
        }
        else
        {
            abilityCD3.SetActive(false);
        }
        if (player.Shoot4Counter != 0 && player.Shoot4Counter < player.shoot4CD)
        {
            abilityCD4.SetActive(true);
            CDtxt4.text = (int)(player.Shoot4Counter) + "";
        }
        else
        {
            abilityCD4.SetActive(false);
        }

        //end game screen
        if (GameManager.FindInstance().health <= 0)
        {
            FindObjectOfType<Timer>().timerIsRunning = false;
            resultScreen.SetActive(true);
            resultScreen.GetComponent<ResultScreen>().showLossScreen();
        }
    }
}
