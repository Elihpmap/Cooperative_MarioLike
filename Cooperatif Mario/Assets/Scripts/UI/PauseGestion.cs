using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGestion : MonoBehaviour
{
    public GameObject UIPause;
    public static bool isPaused;

    private void Start()
    {
        UIPause.SetActive(false);
        isPaused = false;
        Time.timeScale = isPaused ? 0 : 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused || !GameOverGestion.alreadyDead)
            if (Input.GetButtonDown("Cancel"))
            {
                isPaused = !isPaused;
                UIPause.SetActive(!UIPause.activeSelf);
                Button but = UIPause.GetComponentInChildren<Button>();
                if (but) but.Select();
                Time.timeScale = isPaused ? 0 : 1;
            }
    }
}
