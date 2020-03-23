using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    //Intro Screen
    [SerializeField] private GameObject IntroScreenUI;
    [SerializeField] private bool InIntro;
    // Start is called before the first frame update
    void Start()
    {
        ActivateIntroScreen();
    }

    // Update is called once per frame
    void Update()
    {

        if (InIntro)
        {
            ActivateIntroScreen();
        }
        else
        {
            deactivateIntroScreen();
        }
    }
    public void ActivateIntroScreen()
    {
        //pauses the music and activates the pause menu
        AudioListener.pause = true;
        IntroScreenUI.SetActive(true);
        InIntro = true;
    }

    public void deactivateIntroScreen()
    {
        //continues the music and deactivates the pause menu and finally its telling the game to set the isPaused boolean to false

        AudioListener.pause = false;
        IntroScreenUI.SetActive(false);
        InIntro = false;
    }
}
