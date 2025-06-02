using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SounManager : MonoBehaviour
{
   
    public AudioSource playMusic;
    public AudioSource btnsource;
    public AudioSource damage;
    public AudioSource jump;
    public AudioSource mainMusic;
    public AudioSource endMusic;
    
    
    public AudioSource[] sfxsource;
    public AudioClip[] sfxClip;
    public enum Sfx { jump, damage, red, blue, yellow, lever, green }
    int sfxCursor;
    void Start()
    {
        playMusic.volume = PlayerPrefs.GetFloat("BGM", 0.15f);
        btnsource.volume = PlayerPrefs.GetFloat("BTN", 0.45f);
        

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

    }
}