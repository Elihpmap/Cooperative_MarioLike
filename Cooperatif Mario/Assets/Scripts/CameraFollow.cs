using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform maxLeft, maxRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(maxLeft.position.x < this.transform.position.x && maxRight.position.x > this.transform.position.x)
            Camera.main.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        else if (maxRight.position.x < this.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(maxRight.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
        else
        {
            Camera.main.transform.position = new Vector3(maxLeft.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }

    }
}
