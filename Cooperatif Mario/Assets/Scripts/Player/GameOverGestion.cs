using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverGestion : MonoBehaviour
{
    public static bool alreadyDead;
    public GameObject UIGameOver;
    private void Start()
    {
        alreadyDead = false;
    }

    public IEnumerator GameOverStart(float delay)
    {
        // this.gameObject.GetComponent<AudioSource>().Play();
        GameObject Player = GameObject.Find("Player");
        PlayerState PS = Player.GetComponent<PlayerState>();
        if(PS && PS.canBeTouch)
        {
            if (PS.IsPowerUpped)
            {
                PS.ShieldDown();
            }
            else
            {
                Player.GetComponent<Animator>().SetTrigger("Death");

                Player.GetComponent<PlayerMovement>().canMove = false;
                Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

                if (PlayerPrefs.GetInt("Score", 0) < (int)ProgressionChecker.percentageDone)
                    PlayerPrefs.SetInt("Score", (int)ProgressionChecker.percentageDone);
                alreadyDead = true;

                yield return new WaitForSeconds(delay);
                UIGameOver.SetActive(true);
            }
        }

    }

}