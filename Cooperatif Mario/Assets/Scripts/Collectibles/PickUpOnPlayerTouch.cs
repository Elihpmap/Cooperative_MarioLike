﻿using System.Collections;
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
        if (!player) // if player is not set yet we search for the first gameObject with the tag "Player" instead
        {
            player = GameObject.FindWithTag("Player").GetComponent<PlayerState>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch(type)
            {
                case CollectibleType.Ore:
                    PlayerState.orePickedUp++;
                    AkSoundEngine.PostEvent("Play_COIN_COLLECTED", gameObject);
                    break;

                case CollectibleType.PowerUp:
                    player.ShieldUp();
                    AkSoundEngine.PostEvent("Play_BONUS_TAKEN", gameObject);
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
                Destroy(go, 0.0f);
            }

            // launch pickup animation;

            Destroy(parentToDestroy, 0f);

            Destroy(this.gameObject);

        }
    }
}
