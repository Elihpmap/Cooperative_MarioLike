using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbumpDetection : MonoBehaviour
{

    public List<GameObject> prefabToSpawn;
    public bool spawnAllAtFirstBump = false;
    public float spawnAllDelay = 0.2f;

    bool startDelaySpawning = false;
    float timeLeft;

    Vector3 spawnOffset = new Vector3(0f, 0.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        //test Prefab not null
    }

    private void Update()
    {
        if (spawnAllAtFirstBump && startDelaySpawning && prefabToSpawn.Count > 0)
        {
            if (timeLeft <= 0f)
            {
                Instantiate(prefabToSpawn[0], GetComponent<Transform>().position + spawnOffset, Quaternion.identity);
                prefabToSpawn.RemoveAt(0);
                timeLeft = spawnAllDelay;
            }
            else
            {
                timeLeft -= Time.deltaTime;
            }
        }
        else if (prefabToSpawn.Count <= 0)
        {
            startDelaySpawning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && prefabToSpawn.Count > 0)
        {
            if (!spawnAllAtFirstBump)
            {
                Instantiate(prefabToSpawn[0], GetComponent<Transform>().position + spawnOffset, Quaternion.identity);
                prefabToSpawn.RemoveAt(0);
            }
            else
            {
                Instantiate(prefabToSpawn[0], GetComponent<Transform>().position + spawnOffset, Quaternion.identity);
                prefabToSpawn.RemoveAt(0);
                startDelaySpawning = true;
                timeLeft = spawnAllDelay;
            }
        }
    }
}
