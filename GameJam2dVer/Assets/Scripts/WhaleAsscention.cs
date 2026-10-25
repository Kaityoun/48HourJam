using TMPro;
using UnityEngine;

public class WhaleAsscention : MonoBehaviour
{
    public Collider2D cd;
    public Rigidbody2D player;
    public float distance;
    public float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cd = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.y - cd.transform.position.y;
        if (distance < 3f)
        {
            speed = 2.5f;
            DrawplayerCloser();
        }
        if(distance > 10f)
        {
            speed = 14f;
        }
        transform.position += transform.up.normalized * 1f * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("YOU SUCK LOL. GET OUTPLAYED # NERF SHARK");
    }
    void DrawplayerCloser()
    {
        player.AddForce((cd.transform.position - player.transform.position) * 10f);
        // increase drag
    }
    
}
