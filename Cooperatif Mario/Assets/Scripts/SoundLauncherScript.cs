using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLauncherScript : MonoBehaviour
{
    public enum SoundEvent {Play_CAVE_ENTER, Play_CAVE_GET_OUT };
    private string[] stringValue = { "Play_CAVE_ENTER", "Play_CAVE_GET_OUT" };

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
        AkSoundEngine.PostEvent(stringValue[(int)soundToPlay], gameObject);
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
