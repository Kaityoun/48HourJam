using JetBrains.Rider.Unity.Editor;
using UnityEngine;

public class MoonBehavior : MonoBehaviour
{

    public Collider2D cb;
    Vector2 moonLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cb = GetComponent<Collider2D>();
        moonLocation = cb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 rocketLocation = other.transform.position;
        Debug.Log("GRAVITY");
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 rocketLocation = other.transform.position;
        Debug.Log("GRAVITY");
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        // check tags for what the collition item is.
        Vector2 distance = moonLocation * rb.transform.position;
        rb.AddForce(distance * 20 * Time.deltaTime);
        // this does not work as intended right now. just pushes the player rather then pulling it like gravity

    }


}