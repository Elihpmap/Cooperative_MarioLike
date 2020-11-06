using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public bool onShoot = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GameOverGestion.alreadyDead)
        {
            if (onShoot) collision.gameObject.GetComponent<PlayerState>().IsPowerUpped = false;
            GameObject GO = GameObject.Find("GameOver");
            GO.GetComponent<GameOverGestion>().StartCoroutine("GameOverStart", 1f);

            AkSoundEngine.PostEvent("Play_DEATH", gameObject);

        }
    }

}