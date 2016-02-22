﻿using UnityEngine;
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
            float direction = Input.GetAxis("XboxAccel");

            if (direction == 0)
                direction = Input.GetAxis("KeyboardAccel");

            
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
        Turn();
        GearShift();
        



    }
    public float GearDelay = 1f;
    public bool GearShifted = false;
    private void GearShift()
    {
        if (GearShifted)
        {
            
            return;
        }
        


        float gearVal = Input.GetAxis("XboxGearShift");

        if (gearVal == 0)
            return;

        

        if (gearVal > 0)
        {
            if (Gear >= MaxSpeeds.Count)
            {
                Gear = MaxSpeeds.Count;
                return;
            }

            GearShifted = true;
            Gear++;
            StartCoroutine(Shifted());
            return;

        }
        else if (gearVal < 0)
        {
            if (Gear <= 1)
            {
                Gear = 1;
                return;
            }
            GearShifted = true;
            Gear--;
            StartCoroutine(Shifted());
            
        }

    }

    private IEnumerator Shifted()
    {
        yield return new WaitForSeconds(GearDelay);

        GearShifted = false;

    }

    private void Turn()
    {
        float rotation = Input.GetAxis("Horizontal") * TurningSpeed;
        transform.Rotate(0, rotation, 0);
    }

    private void MoveForevard()
    {
        

        rb.AddForce(transform.forward * Speed);
    }
}
