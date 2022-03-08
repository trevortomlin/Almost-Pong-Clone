using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{

    public GameObject paddleLeft;
    public GameObject paddleRight;

    private Vector2 leftDefaultLoc;
    private Vector2 rightDefaultLoc;

    private void Start()
    {
        leftDefaultLoc = paddleLeft.transform.position;
        rightDefaultLoc = paddleRight.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        paddleLeft.transform.position = leftDefaultLoc + Vector2.up * Random.Range(-4, 4);
        paddleRight.transform.position = rightDefaultLoc + Vector2.up * Random.Range(-4, 4);

    }

}
