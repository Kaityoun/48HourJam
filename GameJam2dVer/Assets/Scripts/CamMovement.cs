using UnityEngine;

public class CamMovement : MonoBehaviour
{
    
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(player.position.x,player.position.y + 1f, -5f);
        transform.position = Vector3.Slerp(transform.position, position, 2f * Time.deltaTime);
    }
    
}
