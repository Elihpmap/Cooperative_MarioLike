using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltraBumper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().canMove = false;
            Vector2 dir = new Vector2(- this.transform.position.x + collision.transform.position.x, - this.transform.position.y + collision.transform.position.y);
            GameObject.Find("GameOver").GetComponent<GameOverGestion>().StartCoroutine("GameOverStart", 1f);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = dir * 100;
        }

    }
}
