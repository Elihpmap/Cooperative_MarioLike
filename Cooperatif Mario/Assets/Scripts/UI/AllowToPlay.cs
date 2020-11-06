using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllowToPlay : MonoBehaviour
{
    public Button buttonPlay;

    // Start is called before the first frame update
    void Start()
    {
        if (System.DateTime.Now.DayOfYear > PlayerPrefs.GetInt("DayOfYear", -1) || System.DateTime.Now.Year > PlayerPrefs.GetInt("Year", -1))
        {
            buttonPlay.enabled = true;
        }
        else
        {
            buttonPlay.enabled = false;
        }
    }
}
