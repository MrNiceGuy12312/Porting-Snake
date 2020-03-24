/*
 * Script:                 MoveObjects
 * Autor:                  Damian Jones
 * Date Created:           2019-12-09
 * Date Last Updated:      2019-12-10
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    // scene work
    Scene scene;
    private int index = 0;

    // buttons
    public GameObject m_exitButton;
    public GameObject m_playButton;
    public GameObject m_controlsButton;
    public GameObject m_backButton;
    public GameObject m_creditsButton;
   

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        Time.timeScale = 1.0f;
    }

    void Start()
    {
        // do main menu stuff here
    }

   

    public void PlayButtonPressed()
    {
        // Play Button is pressed
        SceneManager.LoadScene("HarisTesting");
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
