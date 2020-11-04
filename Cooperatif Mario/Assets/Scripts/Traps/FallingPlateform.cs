using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingPlateform : MonoBehaviour
{
    public GameObject plateform;
    public Rigidbody2D rigid;

    public float FallingTime = 1;
    public float FallingSpeed = 2;
    public float TimeBeforeRespawn = 3;
    [SerializeField] private bool Falling;
    [SerializeField] private Vector3 initialPos;
    private float Compt;
    // Start is called before the first frame update
    void Start()
    {
        Falling = false;
        initialPos = plateform.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Compt >= FallingTime + TimeBeforeRespawn)
        {
            Falling = false;
            rigid.velocity = new Vector2(0, 0);
            plateform.transform.localPosition = initialPos;
        }
        else if (Compt > FallingTime)
        {
            rigid.velocity = new Vector2(0, -FallingSpeed);
        }
        if (Falling)
        {
            Compt += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Falling = true;
            Compt = 0;
        }
    }
}