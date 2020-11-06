using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ClicButton : MonoBehaviour
{
    
    public void LoadSceneMode(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void TurnOffPause(GameObject UI)
    {
        PauseGestion.isPaused = false;
        Time.timeScale = 1;
        UI.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    public void switchPanel(GameObject PanelToActiv)
    {
        PanelToActiv.SetActive(true);
        Button but = PanelToActiv.GetComponentInChildren<Button>();
        if (but) but.Select();
        this.gameObject.SetActive(false);
    }
}
