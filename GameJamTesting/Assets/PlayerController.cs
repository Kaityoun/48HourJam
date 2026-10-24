using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float timer;
    public float probelForce = 8f;
    public const float TrueForce = 8f;
    public float velocity;
    public int frameCount;
    public float steeringForce;
    Vector3 startingPosition;
    Vector3 endingPosition;
    public bool isAddingForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frameCount = 1;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.linearVelocity.magnitude;
        isAddingForce = false;

        timer += Time.deltaTime;
        if (Keyboard.current.dKey.isPressed)
        {
            steeringForce = 1.0f;
            
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steeringForce = -1.0f;
        }
        if (Keyboard.current.spaceKey.isPressed && timer > 0.5)
        {
            if(probelForce < 8f)
            {
                probelForce = 8f;
            }
            probelForce += 1f;
            rb.AddForce(Vector3.up * probelForce * Time.deltaTime, ForceMode.Impulse);
            timer = 0;
            isAddingForce = true;
            probelForce++;
        }
        if (isAddingForce == false && timer >= 5)
        {
            probelForce -= 1;
            rb.linearVelocity = Vector3.up * probelForce * Time.deltaTime;
        }
        rb.AddForce(Vector3.right * steeringForce * Time.deltaTime, ForceMode.Impulse);
        steeringForce = 0;
        if(probelForce <= 0)
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
            Vector3 Movement = endingPosition - startingPosition;
            frameCount = 0;
        }
        frameCount++;
    }
}

