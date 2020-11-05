using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GombaFall : MonoBehaviour
{
    public GameObject[] Goombas;
    private bool alreadyFall = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !alreadyFall)
        {
            foreach (GameObject goomba in Goombas)
            {
                goomba.GetComponentInChildren<Rigidbody2D>().isKinematic = false;
            }
            alreadyFall = true;
        }
    }
}
