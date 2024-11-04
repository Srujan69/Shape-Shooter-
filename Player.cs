using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // variables 
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    private int lives;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
        Shooting();

    }

   void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        // if x value is greater than 11.5f, outside the screen from the right 
        if (transform.position.x > 11.5f || transform.position.x <= -11.5f)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //if y<=-3.8 or y>=0
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }
    } 
    void Shooting()
    {
        //shoot a bullet if SPACE is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //create bullet
            Instantiate(bullet, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

        }
    }
}
