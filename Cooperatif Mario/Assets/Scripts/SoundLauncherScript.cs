using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLauncherScript : MonoBehaviour
{
    public enum SoundEvent {test1 , test2};
    public string[] stringValue = { "Play_Tableau3_Part1", "Play_Tableau3_Part1" };

    public SoundEvent soundToPlay = SoundEvent.test1;

    
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
    }
}
