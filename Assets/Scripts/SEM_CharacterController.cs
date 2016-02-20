using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SEM_CharacterController : MonoBehaviour {

    public List<float> MaxSpeeds;
    public int Gear = 1;
    public float AccelerationRate;
    private float CurrentSpeed = 0f;
    public float Speed
    {
        get
        {
            float direction = Input.GetAxis("Vertical");

            
            if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1])
                return direction * MaxSpeeds[Gear - 1];
            else
            {
                CurrentSpeed += AccelerationRate;
                return direction * CurrentSpeed;
            }
           
           

            
        }
    }

    public float TurningSpeed;

    
    Rigidbody _rb;
    Rigidbody rb
    {
        get
        {
            if (_rb == null)
                _rb = GetComponent<Rigidbody>();
            return _rb;
        }
    }

	
	// Update is called once per frame
	void Update () {

        

        MoveForevard();

        float rotation = Input.GetAxis("Horizontal") * TurningSpeed;
        transform.Rotate(0, rotation, 0);



    }

    private void MoveForevard()
    {
        

        rb.AddForce(transform.forward * Speed);
    }
}
