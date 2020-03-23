/*THESE ARE THE VIDEOS I WATCHED TO MAKE THIS HAPPEN*/
/*https://www.youtube.com/watch?v=-2Z7UzhYyTA
https://www.youtube.com/watch?v=lAwSCdSTdYI
https://www.youtube.com/watch?v=tIZ7A3UEkTc&t=1405s */



using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using System.IO;

public class Manager : MonoBehaviour
{
    //The Responsive buttons
    public Toggle fullscreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown textureQualityDropdown;
    public Dropdown antialiasingDropDown;
    public Dropdown vSyncDropdown;
    public Slider musicVolumeSlider;
    public Button applyButton;
    //getting a music source for this specific scene
    public AudioSource musicSource;
    //using the Resolutions dropdown given to you through unity
    public Resolution[] resolutions;
    private GameSettings gameSettings;
    void OnEnable()
    {
        gameSettings = new GameSettings();

        //adding listeners to when a value is changed it calls any of these functions or on clicked aswell
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

    //when Fullscreen toggle is pressed 
    public void OnFullScreenToggle()
    {
       gameSettings.fullScreen = Screen.fullScreen = fullscreenToggle.isOn;
    }
    //when a resolution changed do this 

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }

    //when a texture changed do this
    public void OnTextureQualityChange()
    {
       QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
        
    }

    //when antialiasing is changed do this 
    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow(2f, antialiasingDropDown.value);
    }

    //when vsync is changed do this
    public void OnVsyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.Vsync = vSyncDropdown.value;
    }

    //when the volume slider is being used change the volume
    public void OnMusicVolumeChange()
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }

    //when the apply is pressed load the save settings function
    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    //when saving settings do this
    public void SaveSettings()
    {
        //this saves all the values that were changed in settings into text through a .Json file
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gameSettings.Json", jsonData);
    }

    //loading the settings you saved initially 
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


