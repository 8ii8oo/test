using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.AudioSource;

public class SounManager : MonoBehaviour
{
   
    public AudioSource playMusic;
    public AudioSource btnsource;
    public AudioSource damage;
    public AudioSource jump;
    public AudioSource mainMusic;
    public AudioSource endMusic;
    public static SounManager instance;


    

    void Start()
    {
        
    float bgm = PlayerPrefs.GetFloat("BGM", 0.25f);
    float sfx = PlayerPrefs.GetFloat("BTN", 0.45f);

    playMusic.volume = bgm;
    mainMusic.volume = bgm;
    endMusic.volume = bgm;

    btnsource.volume = sfx;
    jump.volume = sfx;
    damage.volume = sfx;

    } 

    public void SetMusicVolume(float volume)
    {
        playMusic.volume = volume;
        mainMusic.volume = volume;
        endMusic.volume = volume;
        PlayerPrefs.SetFloat("BGM", volume);
        PlayerPrefs.Save();
    }

    public void SetBottonVolume(float volume)
    {
        jump.volume = volume;
        damage.volume = volume;
        btnsource.volume = volume;
        PlayerPrefs.SetFloat("BTN", volume);
        PlayerPrefs.Save();

        
    }




    public void OnBTN()
    {
        btnsource.Play();
        //StartCoroutine(PlayWithDelay());
    }

     //IEnumerator PlayWithDelay()
//{
    //yield return new WaitForSecondsRealtime(0.1f); // 0.1초 대기
   // btnsource.Play();
//}
}