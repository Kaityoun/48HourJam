using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer;
    public float probelForce = 8f;
    public const float TrueForce = 8f;
    public float velocity;
    public int frameCount;
    public float steeringForce;
    public bool isAddingForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frameCount = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.linearVelocity.magnitude;
        isAddingForce = false;

        timer += Time.deltaTime;
        if (Keyboard.current.dKey.isPressed)
        {
            steeringForce = 2.0f;

        }
        if (Keyboard.current.aKey.isPressed)
        {
            steeringForce = -2.0f;
        }
        if (Keyboard.current.spaceKey.isPressed && timer > 0.5)
        {
            if (probelForce < 8f)
            {
                probelForce = 8f;
            }
            probelForce += 1f;
            rb.AddForce(Vector2.up * probelForce * Time.deltaTime, ForceMode2D.Impulse);
            timer = 0;
            isAddingForce = true;
            probelForce += 2;
        }
        if (isAddingForce == false && timer >= 3)
        {
            probelForce -= 1;
            rb.linearVelocity = Vector2.up * probelForce * Time.deltaTime;
        }
        rb.AddForce(Vector2.right * steeringForce * Time.deltaTime, ForceMode2D.Impulse);
        steeringForce = 0;
        if (probelForce <= 0)
        {
            Debug.Log("Gameover");

        }
    }
    void FixedUpdate()
    {

    }
    void Nonsense()
    {
        if (frameCount == 1)
        {
            Vector3 startingPosition = transform.position;
        }
        Vector3 endingPosition = transform.position;
        if (frameCount == 30)
        {
            //Vector3 Movement = endingPosition - startingPosition;
            frameCount = 0;
        }
        frameCount++;
    }
}

