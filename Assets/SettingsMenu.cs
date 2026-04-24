using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    public Slider musicSlider;
    public Slider sfxSlider;
    public TMP_Text musicValueText;
    public TMP_Text sfxValueText;

    [Header("Video")]
    public Toggle fullscreenToggle;

    private const string MusicKey = "MusicVolume";
    private const string SfxKey = "SfxVolume";
    private const string FullscreenKey = "Fullscreen";

    private void Start()
    {
        LoadSettings();

        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(SetMusicVolume);

        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(SetSfxVolume);

        if (fullscreenToggle != null)
            fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MusicKey, value);
        PlayerPrefs.Save();

        if (musicValueText != null)
            musicValueText.text = Mathf.RoundToInt(value * 100f) + "%";

        // Здесь потом можно подключить AudioMixer
        Debug.Log("Music Volume: " + value);
    }

    public void SetSfxVolume(float value)
    {
        PlayerPrefs.SetFloat(SfxKey, value);
        PlayerPrefs.Save();

        if (sfxValueText != null)
            sfxValueText.text = Mathf.RoundToInt(value * 100f) + "%";

        Debug.Log("SFX Volume: " + value);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        PlayerPrefs.SetInt(FullscreenKey, isFullscreen ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("Fullscreen: " + isFullscreen);
    }

    private void LoadSettings()
    {
        float music = PlayerPrefs.GetFloat(MusicKey, 0.8f);
        float sfx = PlayerPrefs.GetFloat(SfxKey, 1.0f);
        bool fullscreen = PlayerPrefs.GetInt(FullscreenKey, 1) == 1;

        if (musicSlider != null)
            musicSlider.value = music;

        if (sfxSlider != null)
            sfxSlider.value = sfx;

        if (fullscreenToggle != null)
            fullscreenToggle.isOn = fullscreen;

        Screen.fullScreen = fullscreen;

        if (musicValueText != null)
            musicValueText.text = Mathf.RoundToInt(music * 100f) + "%";

        if (sfxValueText != null)
            sfxValueText.text = Mathf.RoundToInt(sfx * 100f) + "%";
    }
}