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
    public void PlayButtonPressed()
    {
        // Play Button is pressed
        SceneManager.LoadScene(1);
    }

    public void ControlsButtonPressed()
    {
        // Controls Button is pressed
        SceneManager.LoadScene("Controls");
    }

    public void CreditsButtonPressed()
    {
        // Credits Button is pressed
        SceneManager.LoadScene("Credits");
    }

    public void BackButtonPressed()
    {
        // Play Button is pressed
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGamePressed()
    {
        // exit the game
        Debug.Log("Exit button clicked!");
        Application.Quit();
    }
}

