using UnityEngine;

public class movement_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float xStartPos;
    public float yStartPos;
    public float speed;
    //positions
    private float xpos;
    private float ypos;
    //prefabs
    public GameObject laser;

    void Start()
    {
        transform.position = new Vector3(xStartPos, yStartPos, 0);
    }

    //Use FixedUpdate for movement, updates at a fixed rate, every 16.16 miliseconds
    void FixedUpdate()
    {
        
        
    }

    //rigidbody.moveposition

    void Update()
    {
        //controls movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
}
