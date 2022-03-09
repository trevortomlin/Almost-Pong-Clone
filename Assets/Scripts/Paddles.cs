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

    public void Reset()
    {
        paddleLeft.transform.position = leftDefaultLoc;
        paddleRight.transform.position = rightDefaultLoc;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        FindObjectOfType<AudioManager>().Play("PaddleHit");

        Vector2 leftEndPosition = leftDefaultLoc + Vector2.up * Random.Range(-4, 4);
        Vector2 rightEndPosition = rightDefaultLoc + Vector2.up * Random.Range(-4, 4);

        paddleLeft.transform.position = leftEndPosition;
        paddleRight.transform.position = rightEndPosition;

    }

}
