using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGestion : MonoBehaviour
{
    public GameObject UIPause;
    public static bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (isPaused || !GameOverGestion.alreadyDead)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                UIPause.SetActive(!UIPause.activeSelf);
                Time.timeScale = isPaused ? 0 : 1;
            }
    }
}
