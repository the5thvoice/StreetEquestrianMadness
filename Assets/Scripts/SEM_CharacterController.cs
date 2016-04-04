using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SEM_CharacterController : MonoBehaviour
{
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
            {
                Accelerating = false;
                direction = Input.GetAxis(SEM_ControllerController.Accelerator(PlayerNumber, true));
            }

            if (direction < 0)
            {
                Accelerating = false;
                if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1])
                    CurrentSpeed = 0 - MaxSpeeds[Gear - 1];
                else
                    CurrentSpeed -= AccelerationRate;

            }
            else if (direction > 0)
            {
                Accelerating = true;
                if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1])
                {

                    CurrentSpeed = MaxSpeeds[Gear - 1];
                }
                else
                    CurrentSpeed += AccelerationRate;
            }
            else if (direction == 0 && CurrentSpeed > 0)
                CurrentSpeed -= AccelerationRate;
            else if (direction == 0 && CurrentSpeed < 0)
                CurrentSpeed += AccelerationRate;


            if (Mathf.Abs(CurrentSpeed) >= MaxSpeeds[Gear - 1])
            {

                return direction * MaxSpeeds[Gear - 1];
            }
            else
            {


                return direction * CurrentSpeed;
            }




        }
    }

    private bool Accelerating;
    internal bool isAccelerating()
    {
        return Accelerating;
    }

    public WheelCollider FW;
    public WheelCollider RW;


    public float TurningSpeed;
    public float BankSpeed;


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

    public void FixedUpdate()
    {
        MoveForevard();
    }


    // Update is called once per frame
    void Update()
    {




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
        float rotation = Input.GetAxis(SEM_ControllerController.Horizantal(PlayerNumber, false));

        if (rotation == 0)
        {
            rotation = Input.GetAxis(SEM_ControllerController.Horizantal(PlayerNumber, true));
        }
        //Bank(rotation);


        Vector3 bikeAngles = transform.localEulerAngles;
        toBank = Mathf.Lerp(toBank, rotation, BankSpeed * Time.deltaTime);
        bikeAngles.z = -toBank * bankAngle;
        bikeAngles.x = 0;
        transform.localEulerAngles = bikeAngles;

        rotation *= TurningSpeed;

        FW.steerAngle = rotation;

        //transform.Rotate(0, rotation, 0);
    }


    public float bankAngle;
    float toBank = 0;


    private void MoveForevard()
    {

        RW.motorTorque = Speed;
        FW.motorTorque = Speed;


        //rb.AddForce(transform.forward * Speed);
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
