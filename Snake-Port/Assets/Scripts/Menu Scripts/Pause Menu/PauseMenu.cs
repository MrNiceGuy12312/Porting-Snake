/*THIS IS WHAT I WATCHED TO MAKE THIS HAPPEN - HARIS.S*/
/*https://www.youtube.com/watch?v=pbeB9NsaoPs */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //this allows these private values to be changed in the inspector
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    //Pause Menu Settings
    [SerializeField] private GameObject pauseSettingsUI;
    [SerializeField] private bool inSettings;
    private void Update()
    {
        //when pressing Escape activate the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            activateMenu();
            Time.timeScale = 0f;
        }
        else
        {
            // otherwise its deactivated meaning you arent on the pause screen
            deactivateMenu();
            Time.timeScale = 1f;
        }

        if (inSettings)
        {
            activatePauseSettings();
        }
        else
        {
            deactivatePauseSettings();
        }

    }

    public void activateMenu()
    {
        //pauses the music and activates the pause menu
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        isPaused = true;

    }

    public void deactivateMenu()
    {
        //continues the music and deactivates the pause menu and finally its telling the game to set the isPaused boolean to false

        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void activatePauseSettings()
    {
        //pauses the music and activates the pause menu
        AudioListener.pause = true;
        pauseSettingsUI.SetActive(true);
        inSettings = true;
        isPaused = false;
    }

    public void deactivatePauseSettings()
    {
        //continues the music and deactivates the pause menu and finally its telling the game to set the isPaused boolean to false

        AudioListener.pause = false;
        pauseSettingsUI.SetActive(false);
        inSettings = false;
    }

    public void QuitGame()
    {
        Debug.Log("quitgame");
        Application.Quit();
    }

}
