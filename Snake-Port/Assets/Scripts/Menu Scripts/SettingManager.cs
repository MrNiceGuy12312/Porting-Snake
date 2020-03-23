/*THESE ARE THE VIDEOS I WATCHED TO MAKE THIS HAPPEN*/
/*https://www.youtube.com/watch?v=-2Z7UzhYyTA
https://www.youtube.com/watch?v=lAwSCdSTdYI
https://www.youtube.com/watch?v=tIZ7A3UEkTc&t=1405s */



using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using System.IO;

public class SettingManager : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropDown;
    public Dropdown vSyncDropdown;
    public Slider musicVolumeSlider;
    public Button applyButton;

    public AudioSource musicSource;
    public Resolution[] resolutions;
    private GameSettings gameSettings;
    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        textureQualityDropdown.onValueChanged.AddListener(delegate { OnTextureQualityChange(); });
        antialiasingDropDown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vSyncDropdown.onValueChanged.AddListener(delegate { OnVsyncChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnFullScreenToggle()
    {
       gameSettings.fullScreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    public void OnTextureQualityChange()
    {
       QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
        
    }

    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antialiasingDropDown.value);
    }

    public void OnVsyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.Vsync = vSyncDropdown.value;
    }

    public void OnMusicVolumeChange()
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gameSettings.Json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gameSettings.Json"));

        musicVolumeSlider.value = gameSettings.musicVolume;
        antialiasingDropDown.value = gameSettings.antialiasing;
        vSyncDropdown.value = gameSettings.Vsync;
        textureQualityDropdown.value = gameSettings.textureQuality;
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullScreen;

        Screen.fullScreen = gameSettings.fullScreen;

        resolutionDropdown.RefreshShownValue();

    }
}


