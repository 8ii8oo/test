using UnityEngine;
using UnityEngine.UI;

public class SoundSettingUI : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;
    public SounManager soundManager;

    void Start()
    {

        float bgmValue = PlayerPrefs.GetFloat("BGM", 0.25f);
        float sfxValue = PlayerPrefs.GetFloat("BTN", 0.45f);

        bgmSlider.SetValueWithoutNotify(bgmValue);
        sfxSlider.SetValueWithoutNotify(sfxValue);

  
        bgmSlider.onValueChanged.AddListener(OnBGMChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXChanged);
    }

    void OnBGMChanged(float value)
    {
        soundManager.SetMusicVolume(value);
        PlayerPrefs.SetFloat("BGM", value);
        PlayerPrefs.Save();

        SyncAllSliders();
    }

    void OnSFXChanged(float value)
    {
        soundManager.SetBottonVolume(value);
        PlayerPrefs.SetFloat("BTN", value);
        PlayerPrefs.Save();
        SyncAllSliders();
    }

    void SyncAllSliders()
    {
        SoundSettingUI[] allUIs = GameObject.FindObjectsOfType<SoundSettingUI>();
        foreach (var ui in allUIs)
        {
            if (ui != this)
            {
                ui.bgmSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("BGM", 0.25f));
                ui.sfxSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("BTN", 0.45f));
            }
        }
    }
}
