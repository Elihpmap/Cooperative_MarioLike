﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject UIVictory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Victory");
            StartCoroutine("VictoryDisplay");
        }
    }

    public IEnumerator VictoryDisplay()
    {

        yield return new WaitForSeconds(5);
        UIVictory.SetActive(true);
    }
}
