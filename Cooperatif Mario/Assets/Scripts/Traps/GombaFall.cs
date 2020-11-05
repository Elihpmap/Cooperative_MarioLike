using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GombaFall : MonoBehaviour
{
    public GameObject[] Goombas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(GameObject goomba in Goombas)
        {
            goomba.GetComponentInChildren<Rigidbody2D>().isKinematic = false;
        }
    }
}
