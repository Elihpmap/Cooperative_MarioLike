﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClicButton : MonoBehaviour
{
    
    public void LoadSceneMode(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void TurnOffPause(GameObject UI)
    {
        Time.timeScale = 1;
        UI.SetActive(false);
    }

}
