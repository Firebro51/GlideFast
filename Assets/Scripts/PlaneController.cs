using UnityEngine;
using UnityEngine.XR;

public class PlaneController : MonoBehaviour
{

    // Forces
    // Rigidbody - Gravity- down
    // drag - Slows down forward movement - back
    // thrust - forward Speed - forward
    // Lift - Upward force - up


    public float thrust = 20f;

    public Rigidbody rb; // Gravity and drag





    // Rotation Variables
    // Yaw, Roll, Pitch
    
    public float roll; // Roll - Forward axis  - x axis
    public float yaw; // Yaw - Verticle axis  - y axis
    public float pitch; // Pitch - Frontflip/Backflip - z axis

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        HandleMovement();

        // Look
        HandleDirection();
    }


    // If hit ground die

    // Have set starting speed in air


    public void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Add forward force to rb to see if moving forward works
        }
    }

    public void HandleDirection()
    {
        
    }
}
