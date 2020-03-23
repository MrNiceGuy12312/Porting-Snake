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
    public GameObject m_restartButton;

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

    public void RetryButtonPressed()
    {
        // restart the level
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitGamePressed()
    {
        // exit the game
        Debug.Log("Exit button clicked!");
        Application.Quit();
    }

    public void Win()
    {
        // do level completion stuff here
        scene = SceneManager.GetActiveScene();
        index = scene.buildIndex;
        SceneManager.LoadScene(index += 1, LoadSceneMode.Single);
    }
}
