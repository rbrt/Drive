using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

    bool turningLeft = false,
         turningRight = false,
         accelerating = false,
         braking = false;

    void Start ()
    {
	
	}
	
	void Update ()
    {
	
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
}
