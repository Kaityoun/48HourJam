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
    MoonBehavior moonBehavior;
    public float z;
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
        rb.AddForce(Vector2.up * 10f * Time.deltaTime, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // CLAMING NOW WORKINGS WOOOOOOO
        z = rb.transform.eulerAngles.z;
     
        velocity = rb.linearVelocity.magnitude;
        isAddingForce = false;

        timer += Time.deltaTime;
        if (Keyboard.current.dKey.isPressed)
        {
            turningForce = -45.0f;
            steeringForce = 5f;
            if ( z < 47f || z > 315f)
            {
                rb.transform.Rotate(0, 0, turningForce * Time.deltaTime);
                
            }
            


        }
        if (Keyboard.current.aKey.isPressed)
        {
            turningForce = 45.0f;
            steeringForce = -5f;
            if (z > 313f || z < 45f)
            {
                rb.transform.Rotate(0, 0, turningForce * Time.deltaTime);
            }
            
        }
        
        
        
        if (Keyboard.current.wKey.isPressed && timer > 0.5)
        {
            isAddingForce = true;
            if (probelForce < 8f)
            {
                probelForce = 8f;
            }
            probelForce += 10f;
            rb.AddForce(Vector2.up * probelForce * Time.deltaTime, ForceMode2D.Impulse);
 
            timer = 0;
            
            
        }
        if (Keyboard.current.sKey.isPressed) {
            probelForce -= 3;
            if (probelForce < 8f)
            {
                probelForce = 8f;
            }
        }
        if (isAddingForce == false && timer >= 3)
        {
            probelForce -= 0.2f;
            if (probelForce < 8f)
            {
                probelForce = 8f;
            }
            rb.linearVelocity = Vector2.up * probelForce * Time.deltaTime;
        }
       
            rb.AddForce(Vector2.right * steeringForce * Time.deltaTime, ForceMode2D.Impulse);
        
        steeringForce = 0;
        if (probelForce <= 0)
        {
            Debug.Log("Gameover");

        }
        if (probelForce > 150f)
        {
            probelForce = 150f;
        }


    }
    void FixedUpdate()
    {

    }
    public void forceIncreseer()
    {
        probelForce += 1;
    }
    public void setAddingForceTrue()
    {
        isAddingForce = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        probelForce *= 0.3f * Time.deltaTime;
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

