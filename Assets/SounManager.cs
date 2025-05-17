using UnityEngine;
using UnityEngine.Rendering;

public class SounManager : MonoBehaviour
{
   
    public AudioSource musicsource;
    public AudioSource btnsource;
    void Start()
    {
        musicsource.volume = PlayerPrefs.GetFloat("BGM", 0.15f);
        btnsource.volume = PlayerPrefs.GetFloat("SFX", 0.15f);
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
        PlayerPrefs.SetFloat("SFX", volume);
        PlayerPrefs.Save();
    }

    public void OnSFX()
    {
        btnsource.Play();
    }
}
