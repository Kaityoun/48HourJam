using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class MoonBehavior : MonoBehaviour
{

    public Collider2D cb;
    Vector3 moonLocation;
    public Transform RocketLocation;
    public bool isLeft;
    public float SlingshotIncrease = 1f;
    public MoonBehavior instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        cb = GetComponent<Collider2D>();
        moonLocation = cb.transform.position;
        float leftOfMoon = moonLocation.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.position.x < moonLocation.x) {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }
     void OnTriggerStay2D(Collider2D other)
    {
        PlayerMovement PlayerMovement = GetComponent<PlayerMovement>();
        PlayerMovement.instance.isAddingForce = true;
        SlingshotIncrease++;
        if (isLeft)
        {
            other.transform.RotateAround(moonLocation, Vector3.back * SlingshotIncrease, 45f * Time.deltaTime);
        }
        else
        {
            other.transform.RotateAround(moonLocation, Vector3.forward * SlingshotIncrease, 45f * Time.deltaTime);
        }
        
        PlayerMovement.instance.forceIncreseer();
        PlayerMovement.instance.isAddingForce = true;



    }
     void OnTriggerExit2D(Collider2D other)
    {
        SlingshotIncrease = 1f;
    }
    



}