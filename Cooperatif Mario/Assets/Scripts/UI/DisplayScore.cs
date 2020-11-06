using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    public Slider slider;
    public bool bestScoreToDisplay;
    public TextMeshProUGUI MoneyToDisplay;
    private void Update()
    {
        if (bestScoreToDisplay)
            scoreDisplay.text = "Best Score :" + PlayerPrefs.GetInt("Score", 0) + "%";

        else
            scoreDisplay.text = (int)ProgressionChecker.percentageDone + "%";
        if(slider != null)
        {
            slider.value = (int)ProgressionChecker.percentageDone;
        }
        if (MoneyToDisplay)
        {
            MoneyToDisplay.text = "x " + PlayerState.orePickedUp;
        }
    }
}
