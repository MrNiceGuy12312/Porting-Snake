using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour
{

    public GameObject DelayedStartScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator StartDelay()
    {
        
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {

          yield return 0;
        }
        Debug.Log("holaa");
        DelayedStartScreen.gameObject.SetActive(false);
        Time.timeScale = 1f;


    }
}
