using UnityEngine;

public class enemy_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public float health;
    //timer controls how often the enemy shoots
    public float startTimer;
    private float timer;
    //start positions
    public float start;
    public float end;
    //objects
    public BoxCollider2D bc;
    public Rigidbody2D rb;
    //prefabs
    public GameObject laser;
    //laser time
    public float laser_time;
    //particles
    public ParticleSystem particle_explo;
    //Singleton
    private enemy_manager_script.EnemyController myEnemy = new enemy_manager_script.EnemyController();

    void Start()
    {
        timer = startTimer;
        myEnemy.Start();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (transform.position.x < -8 || transform.position.x > 8)
        {
            speed *= -1;
        }
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        
        if (timer <= 0)
        {
            timer = startTimer;
            Destroy(Instantiate(laser, transform.position, Quaternion.identity), laser_time);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_projectile")
        {
            health--;
            Destroy(Instantiate(particle_explo.gameObject, transform.position, Quaternion.identity), particle_explo.startLifetime);
            if (health <= 0)
            {
                myEnemy.OnDestroy();
                Destroy(gameObject);
            }
        }
    }
}
