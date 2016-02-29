using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SEM_CharacterController : MonoBehaviour {
    public Players PlayerNumber;
    public List<float> MaxSpeeds;
    public int Gear = 1;
    public float AccelerationRate;
    public float CurrentSpeed = 0f;
    public float Speed
    {
        get
        {
            float direction = Input.GetAxis(SEM_ControllerController.Accelerator(PlayerNumber, false));

            if (direction == 0)
                direction = Input.GetAxis(SEM_ControllerController.Accelerator(PlayerNumber, true));

            if (direction < 0)
            {
                if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1])
                    CurrentSpeed = 0 - MaxSpeeds[Gear - 1];
                else
                    CurrentSpeed -= AccelerationRate;

            }
            else if (direction > 0)
            {
                if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1])
                {

                    CurrentSpeed = MaxSpeeds[Gear - 1];
                }
                else
                    CurrentSpeed += AccelerationRate;
            }
            else if (direction == 0 && CurrentSpeed > 0)
                CurrentSpeed -= (CurrentSpeed- GetComponent<Rigidbody>().velocity.magnitude);
            else if (direction == 0 && CurrentSpeed < 0)
                CurrentSpeed += (Mathf.Abs(CurrentSpeed) - GetComponent<Rigidbody>().velocity.magnitude);

            
            if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1]) { 
               
                return direction * MaxSpeeds[Gear - 1];
            }
            else 
            {
                
                
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
        


        float gearVal = Input.GetAxis(SEM_ControllerController.GearShift(PlayerNumber));

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
        float rotation = Input.GetAxis(SEM_ControllerController.Horizantal(PlayerNumber, false)) ;

        if (rotation == 0)
        {
            rotation = Input.GetAxis(SEM_ControllerController.Horizantal(PlayerNumber, true));
        }

        rotation *= TurningSpeed;

        transform.Rotate(0, rotation, 0);
    }

    private void MoveForevard()
    {

        


        rb.AddForce(transform.forward * Speed);
    }


    internal IEnumerator powerUp(float powerScale)
    {
        throw new NotImplementedException();
    }

    internal IEnumerator powerDown(float powerScale)
    {
        float AccelerationRateRestore = AccelerationRate;

        CurrentSpeed *= powerScale;
        AccelerationRate *= powerScale;

        yield return new WaitForSeconds(1);
        AccelerationRate = AccelerationRateRestore;
    }

}
