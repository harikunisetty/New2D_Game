using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField] Text coinsCountTxt;
    [SerializeField] Text KillCountTXT;
    [SerializeField] Image pHealthFill;
    void Start()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
            Instance = this;
        coinsCountTxt.text = "CoinsCount: 00";
        KillCountTXT.text = "KillCount:00";
    }


    public void coinsCountUI()
    {
        coinsCountTxt.text = "CoinsCount: " + GameManager.Instance.Coins.ToString();
    }
    public void KillcountUI()
    {
        KillCountTXT.text = "KillCount: " + GameManager.Instance.Kill1.ToString();
    }
    public void PlayerHealthUI(float value)
    {
        pHealthFill.fillAmount = value * 0.01f;
    }
}
