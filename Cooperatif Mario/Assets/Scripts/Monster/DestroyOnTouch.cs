using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public GameObject parentToDestroy;
    public GameObject[] otherToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach(GameObject go in otherToDestroy)
            {
                Destroy(go, 0.1f);
            }

            Destroy(parentToDestroy, 1f);

        }
    }


}
