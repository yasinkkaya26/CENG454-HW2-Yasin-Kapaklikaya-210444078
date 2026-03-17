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
       
    }

    private void HandleThrust()
    {
        
    }
}