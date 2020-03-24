using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused;

    public GameObject PauseMenu;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }
}
