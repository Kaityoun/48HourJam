using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class MoonBehavior : MonoBehaviour
{
    
    public Collider cb;
    Vector3 moonLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cb = GetComponent<Collider>();
        Vector3 moonLocation = cb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        Vector3 rocketLocation = other.transform.position;
        Debug.Log("GRAVITY");
    }
     void OnTriggerStay(Collider other)
    {
        Vector3 rocketLocation = other.transform.position;
        Debug.Log("GRAVITY");
        Rigidbody rb =other.GetComponent<Rigidbody>();
        // check tags for what the collition item is.
        Vector3 distance = moonLocation - rb.transform.position;
        rb.AddForce(distance * 20 * Time.deltaTime);
        // this does not work as intended right now. just pushes the player rather then pulling it like gravity

    }

}
