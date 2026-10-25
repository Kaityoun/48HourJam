using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    private GameObject player;
    public Transform bulletPosition;

    private float timer;
    public float dangerZone;
    [SerializeField] public AudioClip fireNoise;
    public AudioSource fireSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fireSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);
       // Debug.Log("distance:");
        //Debug.Log(distance);

        if(distance < dangerZone)
        {
            if(timer >2)
            {
                timer = 0;
                fireSource.clip = fireNoise;
                fireSource.Play();
                shoot();
            }
        }
        
    }

    void shoot()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
}
