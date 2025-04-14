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

    public bool isPitch;

    public bool isYaw;
    
    public bool isRoll;

    public Rigidbody rb; // Gravity and drag

    public Transform paperPlane;

    // Action Map

    InputActionMap actionMap;

    // Actions

    InputAction throttleAction;

    InputAction pitchAction;

    InputAction yawAction;

    InputAction rollAction;

    // Rotation Variables
    // Yaw, Roll, Pitch
    
    public float roll = 0.5f; // Roll - Forward axis  - x axis
    public float yaw = 1f; // Yaw - Verticle axis  - y axis
    public float pitch = 1f; // Pitch - Frontflip/Backflip - z axis

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Current plane objects transform
        paperPlane = transform;

        // Action Map
        actionMap = InputSystem.actions.FindActionMap("Player");

        // Actions
        throttleAction = actionMap.FindAction("Throttle");

        pitchAction = actionMap.FindAction("Pitch");

        yawAction = actionMap.FindAction("Yaw");

        rollAction = actionMap.FindAction("Roll");

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
        isThrottling = throttleAction.IsPressed();

        isPitch = pitchAction.IsPressed();

        isYaw = yawAction.IsPressed();

        isRoll = rollAction.IsPressed();

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
        if (isRoll)
        {
            Vector2 rollInput = rollAction.ReadValue<Vector2>();
            rb.AddTorque(transform.forward * -rollInput.x * roll);
            Debug.Log(rollInput);
        }
        if (isPitch)
        {
            Vector2 pitchInput = pitchAction.ReadValue<Vector2>();
            rb.AddTorque(transform.right * pitchInput.y * pitch);
            Debug.Log(pitchInput);
        }
        if (isYaw)
        {
            Vector2 yawInput = yawAction.ReadValue<Vector2>();
            rb.AddTorque(transform.up * yawInput.x * yaw);
            Debug.Log(yawInput);
        }

        // For WASD
        // if (Input.GetKey(KeyCode.D))
        // {
        //     rb.AddTorque(transform.up * 2);
        // }
        // if (Input.GetKey(KeyCode.A))
        // {
        //     rb.AddTorque(transform.up * -2);
        // }
        // if (Input.GetKey(KeyCode.W))
        // {
        //     rb.AddTorque(transform.right * 2);
        // }
        // if (Input.GetKey(KeyCode.S))
        // {
        //     rb.AddTorque(transform.right * -2);
        // }
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
