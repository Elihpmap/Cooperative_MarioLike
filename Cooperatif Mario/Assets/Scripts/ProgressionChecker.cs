using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionChecker : MonoBehaviour
{
    public Transform beginning;
    public Transform end;
    public Transform player;
    public float totalHorizontalDistance;
    public float playerDistance;
    public static float percentageDone = 0;

    // Start is called before the first frame update
    void Start()
    {
        // test no null
        if (!player) // if player is not set yet we search for the first gameObject with the tag "Player" instead
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }
        percentageDone = 0;
        totalHorizontalDistance = end.position.x - beginning.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = player.position.x - beginning.position.x;

        percentageDone = (playerDistance / totalHorizontalDistance) * 100;
    }
}
