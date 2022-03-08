using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int thrust = 1000;

    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.velocity = Vector2.right * 5;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked");
            rb2D.velocity += Vector2.up * 10;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 direction = collision.GetContact(0).normal;

        if (direction.x == 1) {

            rb2D.velocity += Vector2.right * 3 * 2;

        }
        else if (direction.x == -1)
        {
            rb2D.velocity += Vector2.left * 3 * 2;

        }

        Score.score += 1;

    }
    void OnBecameInvisible()
    {
        Debug.Log("I`m gone :(");
    }

}
