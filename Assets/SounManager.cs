using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class SounManager : MonoBehaviour
{
   
    public AudioSource musicsource;
    public AudioSource btnsource;
    public AudioSource[] sfxsource;
    public AudioClip[] sfxClip;
    public enum Sfx { jump, damage, red, blue, yellow, lever, green }
    int sfxCursor;
    void Start()
    {
        musicsource.volume = PlayerPrefs.GetFloat("BGM", 0.15f);
        btnsource.volume = PlayerPrefs.GetFloat("BTN", 0.15f);

    } 

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
        PlayerPrefs.SetFloat("BGM", volume);
        PlayerPrefs.Save();
    }

    public void SetBottonVolume(float volume)
    {
        btnsource.volume = volume;
        PlayerPrefs.SetFloat("BTN", volume);
        PlayerPrefs.Save();
    }

 

    public void OnBTN()
    {
        btnsource.Play();

    }
}