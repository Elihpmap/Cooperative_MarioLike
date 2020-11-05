using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //Les joueur peuvent-il se deplacer
    public bool canMove;
    //vitesse de deplacement
    public float speed = 8;
    public float MaxFallSpeed;
    //Force du saut
    public static int JumpForce = 7;
    //Le joueur touche t'il le sol
    public bool grounded;
    public bool isJumping;
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    //Distance du raycat pour savoir si le joueur touche le sol (= 0.55 environ)
    public float raycast = 1.02f, raycastecart = 0.5f;

    /*
    // Particules lors de l'atterissage
    public Animator particlesAnimator;
    */

    //Rendu Graphique
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D m_Rigidbody2D;

    //Rendu sonore
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        isJumping = false;
        m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpController();
        MovementController();

        if (m_Rigidbody2D.velocity.y < -MaxFallSpeed)
        {
            m_Rigidbody2D.velocity = new Vector3(m_Rigidbody2D.velocity.x, -MaxFallSpeed, m_Rigidbody2D.velocity.x);
        }
    }

    private void MovementController()
    {
        float move = 0;
        if (canMove)
        {
            move = Input.GetAxis("Horizontal");
            m_Rigidbody2D.velocity = new Vector2(move * speed, m_Rigidbody2D.velocity.y);
        }
        spriteRenderer.flipX = (move > 0.1) ? false : (move < -0.1) ? true : spriteRenderer.flipX;
       animator.SetFloat("velocityX", Mathf.Abs(move));
    }

    private void JumpController()
    {
        LayerMask mask = LayerMask.GetMask("Ground") | LayerMask.GetMask("EnemieHead");
        // Si le joueur atterit
        if (!grounded && grounded != Physics2D.Raycast(this.transform.position, Vector2.down, raycast, mask))
        {
            //if (audioSource != null) audioSource.Play();
        }
        grounded = Physics2D.Raycast(this.transform.position + (Vector3.left * raycastecart), Vector2.down, raycast, mask) || Physics2D.Raycast(this.transform.position - (Vector3.left * raycastecart), Vector2.down, raycast, mask);
        animator.SetBool("grounded", grounded);

        if ((canMove))// && !PauseGestion.isPaused)
        {
            if (Input.GetButtonDown("Jump") && grounded)
            {
                m_Rigidbody2D.velocity = Vector2.up * JumpForce;
                jumpTimeCounter = jumpTime;
                isJumping = true;
                if (audioSource != null) audioSource.Play();
                animator.SetTrigger("jump");

            }
            if (Input.GetButton("Jump") && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, JumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else isJumping = false;
            }
            if (Input.GetButtonUp("Jump"))
                isJumping = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlateform")
        {
            if (this.transform.position.x < 0)
            {
            }
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlateform")
        {
            transform.parent = null;
        }
    }
}