// A script that gives a velocity (on the x axis) to a rigidbody and revert this direction if the object cannot move further.
// When it is destroyed, the horizontal velocity is set back to 0.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDeplacement : MonoBehaviour
{
    public float speed = 0f; // needs to be in ]-oo; -0,1] U {0} U [0,1; +oo[
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        //Test rb2D non null
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 actualVelocity = rb2D.velocity;

        if (speed != 0f && actualVelocity.x != speed)
        {

            if ((actualVelocity.x < 0.1f) && (actualVelocity.x > -0.1f))
            {
                speed = -speed;
            }

            rb2D.velocity = new Vector2(speed, actualVelocity.y);
        }
    }

    private void OnDestroy()
    {
        Vector2 actualVelocity = rb2D.velocity;
        rb2D.velocity = new Vector2(0, actualVelocity.y);
    }
}
