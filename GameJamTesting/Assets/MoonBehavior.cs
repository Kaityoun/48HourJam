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
        Debug.DrawRay(moonLocation,rocketLocation, Color.red);
    }
     void OnTriggerStay(Collider other)
    {
        Vector3 rocketLocation = other.transform.position;
        Debug.Log("GRAVITY");
        Rigidbody rb =other.GetComponent<Rigidbody>();
        Vector3 distance = rb.position - moonLocation;
        rb.AddForce(distance * 100 * Time.deltaTime);

    }

}
