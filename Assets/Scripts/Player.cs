using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int thrust = 1000;
    public ParticleSystem deathParticles;

    public float jumpCoolDown = .5f;

    public int maxSpeed = 5;

    private Rigidbody2D rb2D;

    private float jumpTimer = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(new Vector2(400, 0));
        //rb2D.velocity += Vector2.up * 10;
    }

    void Update()
    {
        if (jumpTimer > 0f) {

            jumpTimer -= Time.deltaTime;
        
        }

        else {

            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Clicked");
                //rb2D.velocity = Vector2.zero;
                rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                rb2D.AddForce(new Vector2(0, 400));

                FindObjectOfType<AudioManager>().Play("Jump");

                jumpTimer = jumpCoolDown;

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 direction = collision.GetContact(0).normal;

        if (direction.x == 1) {

            rb2D.AddForce(new Vector2(400, 0));

        }
        else if (direction.x == -1)
        {
            rb2D.AddForce(new Vector2(-400, 0));

        }

        Score.score += 1;

    }
    void OnBecameInvisible()
    {
        Debug.Log("I`m gone :(");

        FindObjectOfType<AudioManager>().Play("Death");

        Instantiate (deathParticles, this.transform.position, Quaternion.identity);

    }

}
