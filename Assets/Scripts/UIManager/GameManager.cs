using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Coins { get => coins; }
    public int Kill1 { get => Kill; }

    private int coins;


    private int Kill;

    public static GameManager Instance;

    [Header("LevelIndex")]
    [SerializeField] int nextLevelIndex;
    [SerializeField] string nextLevelName;
    [SerializeField] LevelObject levelObjective;
    [SerializeField] PlayerMovement playerController;
    [SerializeField] GameObject player;
    public void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }  
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
            playerController = player.GetComponent<PlayerMovement>();
        
      levelObjective =Object.FindObjectOfType<LevelObject>();
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            return;
        }
        if (levelObjective != null && levelObjective.IsObjectiveCompleted)
        {
            LevelEnded();
        }
    }
    void LevelEnded()
    {
        if (playerController != null)
        {

            playerController.enabled = false;

            player.GetComponent<Rigidbody2D>().MovePosition(Vector3.zero);

            LoadNextLevel();
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {

        nextLevelIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;

        LoadNextLevel(nextLevelIndex);
    }
    public void LoadNextLevel(int index)
    {
        if (index > 0 && index <= SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }

    public void LoadNextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
