using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float launchVelocityX = 2f;
    [SerializeField] float launchVelocityY = 12f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0f;

    // State
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached components references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(launchVelocityX, launchVelocityY);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            TweakVelocity();
        }
    }

    private void TweakVelocity()
    {
        if (myRigidBody2D.velocity.x <= 5 && myRigidBody2D.velocity.x >= -5)
        {
            Vector2 xVelocityTweak = new Vector2(Random.Range(0f, randomFactor), 0);
            myRigidBody2D.velocity += (myRigidBody2D.velocity.x > 0) ? xVelocityTweak : -1 * xVelocityTweak;
        }

        if (myRigidBody2D.velocity.y <= 5 && myRigidBody2D.velocity.y >= -5)
        {
            Vector2 yVelocityTweak = new Vector2(0, Random.Range(0f, randomFactor));
            myRigidBody2D.velocity += (myRigidBody2D.velocity.y > 0) ? yVelocityTweak : -1 * yVelocityTweak;
        }
    }
}
