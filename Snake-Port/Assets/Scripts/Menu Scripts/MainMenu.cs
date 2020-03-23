/*THESE ARE THE VIDEOS I WATCHED TO MAKE THIS HAPPEN*/
/*https://www.youtube.com/watch?v=-2Z7UzhYyTA
https://www.youtube.com/watch?v=lAwSCdSTdYI
https://www.youtube.com/watch?v=tIZ7A3UEkTc&t=1405s */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //LOAD GAME
    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    //GO BACK TO MAIN MENU
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");

    }

    //LOAD THE SETTINGS SCREEN
    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsScreen");
    }
    //LOAD CREDITS
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    //LEAVE GAME
    public void QuitGame()
    {
        Application.Quit();
    }
}
