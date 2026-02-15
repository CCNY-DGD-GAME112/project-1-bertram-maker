using UnityEngine;

public class laser_movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, 1);

        if (transform.position.y > 7)
        {
            Destroy(gameObject);
        }
    }
}
