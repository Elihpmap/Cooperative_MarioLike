using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOnPlayerTouch : MonoBehaviour
{
    public enum CollectibleType { Ore, PowerUp };

    public CollectibleType type = CollectibleType.Ore;
    public PlayerState player;

    public GameObject parentToDestroy;
    public GameObject[] toDirectDestroy;
    public GameObject[] toSemiDirectDestroy;

    private void Start()
    {
    // verify that playerstate isn't null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch(type)
            {
                case CollectibleType.Ore:
                    player.orePickedUp++;
                    break;

                case CollectibleType.PowerUp:
                    player.IsPowerUpped = true;
                    break;

                default:
                    break;
            }

            foreach (GameObject go in toDirectDestroy)
            {
                Destroy(go);
            }

            foreach (GameObject go in toSemiDirectDestroy)
            {
                Destroy(go, 0.1f);
            }

            // launch pickup animation;

            Destroy(parentToDestroy, 1f);

            Destroy(this.gameObject);

        }
    }
}
