using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    public GameObject parentToDestroy;
    public GameObject[] otherToDestroy;
    public GameObject[] instantToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (GameObject go in instantToDestroy)
            {
                Destroy(go, 0f);
            }
            foreach (GameObject go in otherToDestroy)
            {
                Destroy(go, 0.2f);
            }

            AkSoundEngine.PostEvent("Play_ALIEN_01_DEATH", gameObject);
            Destroy(parentToDestroy, 1f);

        }
    }


}
