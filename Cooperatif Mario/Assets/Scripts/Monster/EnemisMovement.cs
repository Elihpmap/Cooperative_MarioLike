using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemisMovement : MonoBehaviour
{
    //Position
    public Transform PosLeft, PosRight, Knight;
    private Vector3 InitPos;
    private Vector3 initPosLeft, initPosRight;
    public SpriteRenderer SR;
    public bool LeftRight = true;
    private Quaternion InitRot;
    //public float RotationLeft = -90, RotationRight = 90;
    public float TimeBeforeMove;
    public float Speed;
    public bool GoLeft, init_GoLeft;
    public float count, init_count = 5;
    public bool changeOrientation = true;
    public Rigidbody2D m_Rigidbody2D;
   // public Animator m_anim;


    // Start is called before the first frame update
    void OnEnable()
    {

        InitPos = Knight.GetComponent<Transform>().localPosition;
        InitRot = Knight.GetComponent<Transform>().localRotation;
        m_Rigidbody2D.velocity = new Vector2(0, 0);
        count = init_count;
        GoLeft = init_GoLeft;

        initPosLeft = PosLeft.position;
        initPosRight = PosRight.position;

        Knight.GetComponent<Transform>().localPosition = InitPos;
        Knight.GetComponent<Transform>().localRotation = InitRot;

    }

    // Update is called once per frame
    void Update()
    {

        if (GoLeft && count <= 0)
        {
            if (LeftRight ? Knight.transform.position.x <= initPosRight.x : Knight.transform.position.y <= initPosRight.y)
            {
                m_Rigidbody2D.velocity = LeftRight ? new Vector2(Speed, m_Rigidbody2D.velocity.y) : new Vector2(m_Rigidbody2D.velocity.x, Speed);
            }
            else
            {
                m_Rigidbody2D.velocity = LeftRight ? new Vector2(0, m_Rigidbody2D.velocity.y) : new Vector2(m_Rigidbody2D.velocity.x, 0);
                GoLeft = false;
                count = TimeBeforeMove;

            }
            if (changeOrientation)
            {
               // this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationLeft));
              //  this.transform.localPosition = new Vector3(0.64f, -0.7f, 0);
                SR.flipX = false;
            }
        }
        else if (!GoLeft && count <= 0)
        {
            if (LeftRight ? Knight.transform.position.x >= initPosLeft.x : Knight.transform.position.y >= initPosLeft.y)
            {
                m_Rigidbody2D.velocity = LeftRight ? new Vector2(-Speed, m_Rigidbody2D.velocity.y) : new Vector2(m_Rigidbody2D.velocity.x, -Speed);
            }
            else
            {
                m_Rigidbody2D.velocity = LeftRight ? new Vector2(0, m_Rigidbody2D.velocity.y) : new Vector2(m_Rigidbody2D.velocity.x, 0);
                GoLeft = true;
                count = TimeBeforeMove;
            }
            if (changeOrientation)
            {
                SR.flipX = true;
              //  this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, RotationRight));
              //  this.transform.localPosition = new Vector3(-0.64f, -0.7f, 0);

            }
        }
        else if (count >= 0)
        {
            count -= Time.deltaTime;
        }
        //m_anim.SetFloat("velocityX", Mathf.Abs(m_Rigidbody2D.velocity.x));
    }

}