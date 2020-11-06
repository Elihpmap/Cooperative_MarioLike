// A script to manage the number of Ore collected and the actual state of the player (if they have a powerUp or not)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool IsPowerUpped = false;
    public GameObject Shield;
    public static int orePickedUp;
    public bool canBeTouch;
    public float delay = 1f;

    private void Start()
    {
        canBeTouch = true;
        orePickedUp = 0;
    }

    public void ShieldUp()
    {
        IsPowerUpped = true;
        Shield.SetActive(true);
    }
    public void ShieldDown()
    {
        IsPowerUpped = false;
        Shield.GetComponent<Animator>().SetTrigger("ShieldDown");
        StartCoroutine("CooldownBeforeNextHit",delay);
    }

    public IEnumerator CooldownBeforeNextHit(float delay)
    {
        canBeTouch = false;
        yield return new WaitForSeconds(delay);
        Shield.SetActive(false);
        canBeTouch = true;
    }
}
