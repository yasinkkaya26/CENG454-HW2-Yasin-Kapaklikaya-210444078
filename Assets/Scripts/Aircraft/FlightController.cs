// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Yasin Kapaklıkaya | Student ID: 210444078

using UnityEngine;

public class FlightController : MonoBehaviour {
    [SerializeField] private float pitchMultiplier = 45f; 
    [SerializeField] private float yawMultiplier = 45f; 
    [SerializeField] private float rollingMultiplier = 45f; 
    [SerializeField] private float thrustMultiplier = 5f; 

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
        
    }

    void Update() {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
       float inputPitch = 0f;
       float inputYaw = 0f;
       float inputRoll = 0f;

       if (Input.GetKey(KeyCode.UpArrow))
       {
        inputPitch = 1f;
       }
       else if (Input.GetKey(KeyCode.DownArrow))
       {
        inputPitch = -1f;
       }


       if (Input.GetKey(KeyCode.RightArrow))
        {
            inputYaw = -1f;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            inputYaw = 1f;
        }


        if (Input.GetKey(KeyCode.Q))
        {
            inputRoll = 1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            inputRoll = -1f;
        }

       transform.Rotate(Vector3.right * inputPitch * pitchMultiplier * Time.deltaTime, Space.Self);
       transform.Rotate(Vector3.up * inputYaw * yawMultiplier * Time.deltaTime, Space.Self);
       transform.Rotate(Vector3.forward * inputRoll * rollingMultiplier * Time.deltaTime, Space.Self);
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustMultiplier * Time.deltaTime, Space.Self);
        }
        
    }
}