using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLifeCycle : MonoBehaviour
{
    public GameObject pauseObject;
    public GameObject pauseButton;
    public GameObject resumeButton;

    public void Pause()
    {
        Time.timeScale = 0;
        pauseObject.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseObject.SetActive(false);
    }

    public void OnApplicationFocus(bool focus)
    {
        if(!focus)
        {
            Pause();
        }
    }

    public void onPauseButtonPressed()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        Pause();
    }
    public void onResumeButtonPressed()
    {
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        Resume();
    }
}
