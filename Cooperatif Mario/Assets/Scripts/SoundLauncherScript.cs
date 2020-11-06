using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLauncherScript : MonoBehaviour
{
    public enum SoundEvent {Music1, Music2, Music3, Play_CAVE_ENTER, Play_CAVE_GET_OUT };
    private string[] stringValue = { "_MAIN_LEVEL_PART1_90_BPM", "_MAIN_LEVEL_PART2_90_BPM", "_MAIN_LEVEL_PART3_60_BPM", "_CAVE_ENTER", "_CAVE_GET_OUT" };

    public SoundEvent soundToPlay = SoundEvent.Play_CAVE_ENTER;

    public GameObject[] toActivate;
    public GameObject[] toDeactivate;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AkSoundEngine.PostEvent("Play" + stringValue[(int)soundToPlay], gameObject);
        foreach (GameObject go in toActivate)
        {
            go.SetActive(true);
        }

        foreach (GameObject go in toDeactivate)
        {
            go.SetActive(false);
        }
    }


}
