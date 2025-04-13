using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class PlaneController : MonoBehaviour
{

    // Forces
    // Rigidbody - Gravity- down
    // drag - Slows down forward movement - back
    // thrust - forward Speed - forward
    // Lift - Upward force - up

    public float thrust = 20f;

    public float lift;

    public bool isThrottling;

    public Rigidbody rb; // Gravity and drag

    public Transform paperPlane;


    // Action Map

    InputActionMap actionMap;

    // Rotation Variables
    // Yaw, Roll, Pitch
    
    public Vector3 roll = new Vector3(10f, 0, 0); // Roll - Forward axis  - x axis
    public Vector3 yaw = new Vector3(0, 10f, 0); // Yaw - Verticle axis  - y axis
    public Vector3 pitch = new Vector3(0, 0, 10f); // Pitch - Frontflip/Backflip - z axis

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Current plane objects transform
        paperPlane = transform;

        // Action Map
        actionMap = InputSystem.actions.FindActionMap("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isThrottling)
        {
            HandleMovement();
        }
        HandleDirection();
    }

    void Update()
    {
        // If Throttle is pressed set true , else set false
        isThrottling = actionMap.FindAction("Throttle").IsPressed();
    }


    // If hit ground die

    // Have set starting speed in air


    public void HandleMovement()
    {
        // Add forward force to rb to see if moving forward works
        Vector3 beans = rb.centerOfMass;
        beans.z += 0.5f;
        Vector3 offset = transform.TransformPoint(beans);
        rb.AddForceAtPosition(transform.forward * thrust, offset);
    }

    public void HandleDirection()
    {
        // For WASD
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * 2);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.up * -2);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddTorque(transform.right * 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddTorque(transform.right * -2);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(transform.forward * 1f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(transform.forward * -1f);
        }
    }
}
