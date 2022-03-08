using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddles : MonoBehaviour
{

    public GameObject paddleLeft;
    public GameObject paddleRight;

    private Vector3 leftDefaultLoc;
    private Vector3 rightDefaultLoc;


    private void Start()
    {
        leftDefaultLoc = paddleLeft.transform.position;
        rightDefaultLoc = paddleRight.transform.position;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        FindObjectOfType<AudioManager>().Play("PaddleHit");

        Vector3 leftEndPosition = leftDefaultLoc + Vector3.up * Random.Range(-4, 4);
        Vector3 rightEndPosition = rightDefaultLoc + Vector3.up * Random.Range(-4, 4);

        paddleLeft.transform.position = leftEndPosition;
        paddleRight.transform.position = rightEndPosition;

    }

}
