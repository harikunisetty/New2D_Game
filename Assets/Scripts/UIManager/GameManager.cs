using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Coins { get => coins; }
    public int Kill1 { get => Kill; }

    private int coins;


    private int Kill;

    public static GameManager Instance;
    void Start()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateCoins()
    {
        coins++;

        UiManager.Instance.coinsCountUI();
    }
    public void UpdateKills()
    {
        Kill++;

        UiManager.Instance.KillcountUI();
    }
}
