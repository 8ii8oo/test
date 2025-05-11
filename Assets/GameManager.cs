using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Intro,
    Playing,
    Dead
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state = GameState.Intro;
    public int Live = 3;
    public float playerStartTime;

    [Header("References")]
    public GameObject enemySpawner;
    public GameObject IntroUI;
    public GameObject overBackground;
    public testHealth PlayerScript;

    public TMP_Text scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

   void Start()
{
    if (PlayerPrefs.GetInt("Retry", 0) == 1)
    {
        IntroUI.SetActive(false);
        enemySpawner.SetActive(true);
        scoreText.gameObject.SetActive(false);
        state = GameState.Playing;
        playerStartTime = Time.time;

        PlayerPrefs.SetInt("Retry", 0); 
    }
    else
    {
        IntroUI.SetActive(true); 
    }
}

    float CalCulateScore()
    {
        return (Time.time - playerStartTime) * 20f;
    }

    void SaveHighScore()
    {
        int score = Mathf.FloorToInt(CalCulateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if (state == GameState.Playing)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "점수:" + Mathf.FloorToInt(CalCulateScore());
        }
        if (state == GameState.Playing && Live == 0)
        {
            PlayerScript.KillPlayer();
            enemySpawner.SetActive(false);
            overBackground.SetActive(true);
            state = GameState.Dead;
            scoreText.text = "점수: " + GetHighScore() + "점";
        }
    }

    public void OnClickStart()
    {
        state = GameState.Playing;
        IntroUI.SetActive(false);
        enemySpawner.SetActive(true);
        playerStartTime = Time.time; 
    }

   public void OnClickRetry()
{
    if (state == GameState.Dead)
    {
        PlayerPrefs.SetInt("Retry", 1); 
        SceneManager.LoadScene("SampleScene");
    }
}

int GetHighScore()
{
    return PlayerPrefs.GetInt("highScore");
}

    public void OnClickExit()
    {
        if (state == GameState.Dead)
        {
            
            SceneManager.LoadScene("SampleScene");
        }
    }
}