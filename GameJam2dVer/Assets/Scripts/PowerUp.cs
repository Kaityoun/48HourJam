using Unity.VisualScripting;
using UnityEngine;


public class PowerUp : MonoBehaviour
{

    public PlayerMovement player;
    public GameObject PowerBox;
    public bool PoweredUp;
    public float timing;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SlowDown ()
    {
        timing -= Time.deltaTime;
        player.rb.AddForce(Vector2.up * player.probelForce * Time.deltaTime, ForceMode2D.Impulse);
        player.isAddingForce = true;
        player.probelForce -= 3f;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player.probelForce = 60f;
            player.rb.linearVelocity = Vector2.up * (player.probelForce + 5f) * Time.deltaTime;
            Debug.Log("Power-up initiated!" + player.probelForce);
            PowerBox.SetActive(false);
            Debug.Log(player.probelForce);

        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PoweredUp = true;
        timing = 0.5f;
        while (timing > 0)
        {
            SlowDown();
            Debug.Log("Powerup depleting");
            timing -= Time.deltaTime;
        }

        Debug.Log("Powerup depeleted");
        

    }



}
