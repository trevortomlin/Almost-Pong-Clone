using UnityEngine;

public class Player : MonoBehaviour
{

    public CameraShake cameraShake;

    [Header("Jump")]
    public int thrust = 400;
    public float jumpCoolDown = .5f;
    private float jumpTimer = 0f;

    [Header("Particles")]
    public ParticleSystem deathParticles;
    public ParticleSystem hitPaddleParticles;

    [Header("RigidBody")]
    private Rigidbody2D rb2D;
    private Vector2 rb2DStartPos;
    
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2DStartPos = rb2D.position;
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void ApplyStartForce()
    {

        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        rb2D.AddForce(new Vector2(thrust, 0));

    }

    public void Reset()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.position = rb2DStartPos;
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {
        if (jumpTimer > 0f) {

            jumpTimer -= Time.deltaTime;
        
        }

        else {

            if (Input.GetMouseButtonDown(0))
            {

                rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
                rb2D.AddForce(new Vector2(0, thrust));

                FindObjectOfType<AudioManager>().Play("Jump");

                jumpTimer = jumpCoolDown;

            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        StartCoroutine(cameraShake.Shake(.2f, .1f));

        Vector2 direction = collision.GetContact(0).normal;

        if (direction.x == 1) {

            rb2D.AddForce(new Vector2(thrust, 0));
            Instantiate(hitPaddleParticles, this.transform.position, Quaternion.identity);

        }
        else if (direction.x == -1)
        {
            rb2D.AddForce(new Vector2(-thrust, 0));
            Instantiate(hitPaddleParticles, this.transform.position, Quaternion.identity);

        }

        Score.score += 1;

    }
    void OnBecameInvisible()
    {

        StartCoroutine(cameraShake.Shake(.2f, .4f));

        FindObjectOfType<AudioManager>().Play("Death");

        Instantiate (deathParticles, this.transform.position, Quaternion.identity);

        int highScore = Mathf.Max(PlayerPrefs.GetInt("HighScore"), Score.score);

        PlayerPrefs.SetInt("HighScore", highScore);

        FindObjectOfType<GameManager>().Reset();

    }

}
