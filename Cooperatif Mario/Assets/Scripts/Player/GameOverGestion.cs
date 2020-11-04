using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverGestion : MonoBehaviour
{
    public static bool alreadyDead;
    private void Start()
    {
        alreadyDead = false;
    }

    public IEnumerator GameOverStart(float delay)
    {
           // this.gameObject.GetComponent<AudioSource>().Play();
            alreadyDead = true;
            GameObject Player = GameObject.Find("Player");

            Player.GetComponent<Animator>().SetTrigger("Death");

            Player.GetComponent<PlayerMovement>().canMove = false;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            yield return new WaitForSeconds(delay);

    }

}