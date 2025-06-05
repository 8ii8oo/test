using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Intro,
    Playing,
    Dead,
    Option
}

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public GameState state = GameState.Intro;
    public int Live = 3;
    public float playerStartTime;
    public static bool GameIsPaused = false;
    public GameObject player;

  
    [Header("Sound")]
    public AudioSource playMusic;
    public AudioSource mainMusic;
    public AudioSource endMusic;



    [Header("References")]
    public GameObject enemySpawner;
    public GameObject IntroUI;
    public GameObject overBackground;
    public testHealth PlayerScript;
    public GameObject Setting;
    public GameObject mainSetting;
    public playermove playermoveScript;

    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;
    public enum Sfx { jump, damage = 3, red, blue, yellow, lever, green };
    int sfxCursor;


    public TMP_Text scoreText;
    public TMP_Text endScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        

        Time.timeScale = 1f;
        SaveHighScore();

        if (PlayerPrefs.GetInt("Retry", 0) == 1) //처음 시작 화면 & 재시작 화면
        {
            IntroUI.SetActive(false);
            enemySpawner.SetActive(true);
            scoreText.gameObject.SetActive(true);
            state = GameState.Playing;
            playerStartTime = Time.time;
            Time.timeScale = 1f;
            mainMusic.Stop();
            playMusic.Play();

            PlayerPrefs.SetInt("Retry", 0);
        }
        else
        {
            IntroUI.SetActive(true);
        }
    }


    float CalCulateScore() //스코어 점수 속도
    {
        return (Time.time - playerStartTime) * 20f;
    }

    void SaveHighScore() //점수 저장
    {
        int score = Mathf.FloorToInt(CalCulateScore());
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        if (state == GameState.Playing) //다죽자상태
        {
            scoreText.gameObject.SetActive(true); 
            scoreText.text = "점수: " + Mathf.FloorToInt(CalCulateScore());
        }
        if (state == GameState.Playing && Live == 0)
        {
            state = GameState.Dead; 
            PlayerScript.KillPlayer();
            playMusic.Stop();
            StartCoroutine(ShowGameOverAfterDelay());
        
        }

        //esc버튼 눌렀을 때 설정 띄우기(BGM, 효과음, 계속하기, 메인화면, 게임종료)
        if (Input.GetKeyDown(KeyCode.Escape) && state == GameState.Playing)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pasue();
            }
        }

    }
    IEnumerator ShowGameOverAfterDelay()
    {

        Invoke("TimeZero", 0.5f);


        yield return new WaitForSecondsRealtime(2f);
        
        endMusic.Play();

        overBackground.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScore.text = Mathf.FloorToInt(CalCulateScore() - 10) + "점";

        SaveHighScore();
    }

    void TimeZero()
    {
        Time.timeScale = 0f;
    }


    public void OnClickStart() //게임시작 버튼 눌렀을 때 
    {
        playMusic.Play();
        mainMusic.Stop();
        state = GameState.Playing;
        IntroUI.SetActive(false);
        enemySpawner.SetActive(true);
        playerStartTime = Time.time;
    }

    public void OnClickRetry() //죽었을 때 다시하기 버튼
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

    public void OnClickExit() //게임종료 버튼 눌렀을 때 메인화면으로 나가기
    {
        if (state == GameState.Intro)
        {
            Application.Quit();
        }
    }


    public void OnClickPlay()
    {
        if (GameIsPaused == true)
        {
            Resume();
        }
    }
    public void Pasue()
    {
        Setting.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Resume()
    {
        Setting.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void OnClickSetting()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && state != GameState.Dead)
        {
            state = GameState.Option;

        }
    }

    public void OnClickMain() //메인화면으로 이동
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Retry", 0);
        SceneManager.LoadScene("SampleScene");
        Setting.SetActive(false);

    }

    public void OnClickMainSet()
    {
        if (state == GameState.Intro)
        {
            mainSetting.SetActive(true);
        }
    }

    public void OnClickMainBot()
    {
        mainSetting.SetActive(false);
    }


}