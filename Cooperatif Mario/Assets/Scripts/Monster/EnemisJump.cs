using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemisJump : MonoBehaviour
{
    public bool canJumpOnPlayer;
    public Rigidbody2D m_Rigidbody2D;
    public static bool EverybodyJUMP;
    public float JumpForce;

    private bool jump, isJumping, grounded;

    private float jumpTimeCounter;
    //Distance du raycat pour savoir si le joueur touche le sol (= 0.55 environ)
    public float raycast = 0.55f, raycastecart = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

        EverybodyJUMP = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(EverybodyJUMP || jump)
        {
            LayerMask mask = LayerMask.GetMask("Ground") | LayerMask.GetMask("Glass");
            grounded = Physics2D.Raycast(this.transform.position + (Vector3.left * raycastecart), Vector2.down, raycast, mask) || Physics2D.Raycast(this.transform.position - (Vector3.left * raycastecart), Vector2.down, raycast, mask);

            if (grounded)
            {
                m_Rigidbody2D.velocity = Vector2.up * JumpForce;
                isJumping = true;

            }
            if (isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, JumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else isJumping = false;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canJumpOnPlayer) jump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canJumpOnPlayer) jump = false;
        }
    }
}
