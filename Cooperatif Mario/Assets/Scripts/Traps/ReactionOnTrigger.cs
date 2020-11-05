using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionOnTrigger : MonoBehaviour
{
    public GameObject m_gameobject;
    public GameObject Sprite;
    public bool willAppear, willDisAppear, goToTarget;
    public bool willReAppear, willReDisAppear;
    public float speed = 0;
    public Transform target;

    private Vector3 posVec;
    private bool move;

    // Start is called before the first frame update
    void Start()
    {
        posVec = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            m_gameobject.transform.position = Vector3.MoveTowards(transform.position, posVec, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (goToTarget) move = true;
            if (willAppear) Sprite.SetActive(true);
            if (willDisAppear) Sprite.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (willReAppear) Sprite.SetActive(true);
            if (willReDisAppear) Sprite.SetActive(false);
        }
    }
}
