using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
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
    void Awake()
    {
        instance = this;
    }
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
            rb.transform.Rotate(0, 0, turningForce * Time.deltaTime);


        }
        if (Keyboard.current.aKey.isPressed)
        {
            turningForce = 45.0f;
            steeringForce = -3f;
            rb.transform.Rotate(0, 0, turningForce * Time.deltaTime);
        }
        
        Mathf.Clamp(transform.rotation.z, -45f, 45f);
        // claming does not work
        if (Keyboard.current.spaceKey.isPressed && timer > 0.5)
        {
            isAddingForce = true;
            if (probelForce < 8f)
            {
                probelForce = 8f;
            }
            probelForce += 10f;
            rb.AddForce(Vector2.up * probelForce * Time.deltaTime, ForceMode2D.Impulse);
 
            timer = 0;
            
            probelForce += 5;
        }
        if (isAddingForce == false && timer >= 3)
        {
            probelForce -= 1;
            if (probelForce < 0)
            {
                probelForce = 1;
            }
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
    public void forceIncreseer()
    {
        probelForce += 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        probelForce *= 0.9f* Time.deltaTime;
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

