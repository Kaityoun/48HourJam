using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Rigidbody2D rb;
    public float timer;
    public float probelForce = 8f;
    public const float TrueForce = 8f;
    public float velocity;
    public int frameCount;
    public float steeringForce =3f;
    public float turningForce;
    public bool isAddingForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        frameCount = 1;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.linearVelocity.magnitude;
        isAddingForce = false;

        timer += Time.deltaTime;
        if (Keyboard.current.dKey.isPressed)
        {
            turningForce = -45.0f;
            steeringForce = 3f;
            rb.transform.Rotate(0,0, turningForce * Time.deltaTime);


        }
        if (Keyboard.current.aKey.isPressed)
        {
            turningForce = 45.0f;
            steeringForce = -3f;
            rb.transform.Rotate(0, 0, turningForce * Time.deltaTime);
        }
        if (Keyboard.current.spaceKey.isPressed && timer > 0.5)
        {
            if (probelForce < 8f)
            {
                probelForce = 8f;
            }
            probelForce += 10f;
            rb.AddForce(Vector2.up * probelForce * Time.deltaTime, ForceMode2D.Impulse);
            timer = 0;
            isAddingForce = true;
            probelForce += 5;
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
    void GravitySling() { }
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

