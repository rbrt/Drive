using UnityEngine;
using System.Collections;

public class PhysicsCarController : MonoBehaviour
{

    [SerializeField] protected WheelCollider[] rearWheels;
    [SerializeField] protected WheelCollider[] frontWheels;

    [SerializeField] protected float turningSpeed = 1;
    [SerializeField] protected float accelerationSpeed = 1;
    [SerializeField] protected float maxSteeringAngle = 30;

    bool turningLeft = false,
         turningRight = false,
         accelerating = false,
         braking = false;

    void Awake()
    {
        
    }

    void Update()
    {
        HandleInput();
        ApplyForces();
    }

    void HandleInput()
    {
        // Press Right
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            turningRight = true;
            turningLeft = false;
        }
        // Press Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            turningLeft = true;
            turningRight = false;
        }
        // Press Up
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            accelerating = true;
        }
        // Press Down
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            braking = true;
        }

        // Release Right
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            turningRight = false;
        }
        // Release Left
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            turningLeft = false;
        }
        // Release Up
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            accelerating = false;
        }
        // Release Down
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            braking = false;
        }
    }

    void ApplyForces()
    {
        if (turningRight && !turningLeft)
        {
            RotateFrontWheels(turningSpeed);
        }
        else if (turningLeft && !turningRight)
        {
            RotateFrontWheels(-turningSpeed);
        }
        else
        {
            StraightenWheels();
        }

        if (accelerating)
        {
            AddForceToRearWheels(accelerationSpeed);
        }
    }

    void AddForceToRearWheels(float force)
    {
        rearWheels[0].motorTorque += force;
        rearWheels[1].motorTorque += force;
    }

    void RotateFrontWheels(float angle)
    {
        frontWheels[0].steerAngle = Mathf.Clamp(frontWheels[0].steerAngle + angle, -maxSteeringAngle, maxSteeringAngle);
        frontWheels[1].steerAngle = Mathf.Clamp(frontWheels[1].steerAngle + angle, -maxSteeringAngle, maxSteeringAngle);
    }

    void StraightenWheels()
    {
        if (frontWheels[0].steerAngle < 0)
        {
            frontWheels[0].steerAngle = Mathf.Min(frontWheels[0].steerAngle + turningSpeed, 0);
            frontWheels[1].steerAngle = Mathf.Min(frontWheels[0].steerAngle + turningSpeed, 0);
        }
        else
        {
            frontWheels[0].steerAngle = Mathf.Max(frontWheels[0].steerAngle - turningSpeed, 0);
            frontWheels[1].steerAngle = Mathf.Max(frontWheels[0].steerAngle - turningSpeed, 0);
        }
    }

}
