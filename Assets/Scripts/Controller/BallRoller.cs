using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRoller : MonoBehaviour
{
    public int level = 1;
    public float torqueAmount;
    private Vector3 cameraOffset;

    private bool isPressing = false;
    private Vector2 originalPressPoint = Vector2.zero;
    private Rigidbody ballRigidbody; //Define a rigidbody to find it at start then use it in Update.
    private Camera mainCam; //Same as rigidbody, define a camera to find the main camera.\
    private GameObject playerBall;
    private Vector3 initPos;

    private void Awake()
    {
        MyEventSystem.I.StartLevel(PlayerPrefs.GetInt("Level"));
        EventManager.LevelEvents.onLevelPassed+=SuccessLevelHandler;
        EventManager.LevelEvents.onLevelFailed+=FailLevelHandler;
    }

    private void Start()
    {
        //Create a reference for more clear and understandable code.
        playerBall = GameObject.Find("PlayerBall");

        //Set the mainCam as Main Camera
        mainCam = Camera.main;

        cameraOffset = playerBall.transform.position - mainCam.transform.position;

        //Set ballRigidbody as the rigidbody that is attached to the playerBall
        ballRigidbody = playerBall.GetComponent<Rigidbody>();

        initPos = playerBall.transform.position;

    }

    

    //Use FixedUpdate to make a calculations with Physics you can get better results in terms of smooth control
    private void FixedUpdate()
    {
        // var ballRigidbody = GameObject.Find("PlayerBall").GetComponent<Rigidbody>(); /* Do not trying to find gameObject's rigidbody every frame, you can call it in start then with its reference you can make your calculations. */

        if (Input.GetMouseButton(0))
        {
            if (!isPressing)
            {
                originalPressPoint = Input.mousePosition;
                isPressing = true;
            }
            else
            {
                Vector2 diff = (originalPressPoint - new Vector2(Input.mousePosition.x, Input.mousePosition.y)).normalized;
                
                //Make sure the rigidbody is not null
                if (ballRigidbody)
                {
                    ballRigidbody.AddTorque((Vector3.forward * diff.x + Vector3.right * -diff.y) * torqueAmount, ForceMode.VelocityChange);    
                }
                
            }
        }
        else
        {
            isPressing = false;
        }
        
        //Make sure the mainCam is not null
        if (mainCam)
        {
            mainCam.transform.position = ballRigidbody.transform.position - cameraOffset;
        }
        
    }

    private void SuccessLevelHandler()
    {
        ballRigidbody.velocity=Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.rotation = Quaternion.Euler(0,0,0);
        playerBall.transform.position = initPos;
    }
    private void FailLevelHandler()
    {
        ballRigidbody.velocity=Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        ballRigidbody.rotation = Quaternion.Euler(0,0,0);
        playerBall.transform.position = initPos;
    }

    
}
