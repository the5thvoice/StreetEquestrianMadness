using UnityEngine;
using System.Collections;
using System;

public class SEM_CameraController : MonoBehaviour {

    public Transform Target;

    public Vector3 CameraAngle = Vector3.zero;

    public float minFOV;
    public float maxFOV;

    private Camera _Cam;

    public Camera Cam
    {
        get
        {
            if (_Cam == null)
                _Cam = GetComponent<Camera>();
            return _Cam;


        }
    }
    private SEM_CharacterController _Character;

    public SEM_CharacterController Character
    {
        get 
        {
            if (_Character == null)
            {
                _Character = GetComponentInParent<SEM_CharacterController>();
            }

            return _Character;
        }
    }

	// Use this for initialization
	void Start () {

        CameraAngle = transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update ()
	{


	    LockTiltAngle();
	    AccelerationEffect();






	}

    private void AccelerationEffect()
    {
        if (Character.isAccelerating())
        {
            Cam.fieldOfView += Character.AccelerationRate*Time.deltaTime;

            if (Cam.fieldOfView >= maxFOV)
                Cam.fieldOfView = maxFOV;
        }
        else
        {
            Cam.fieldOfView -= Character.AccelerationRate * Time.deltaTime;

            if (Cam.fieldOfView <= minFOV)
                Cam.fieldOfView = minFOV;

        }
    }

    private void LockTiltAngle()
    {
        CameraAngle = transform.eulerAngles;

        CameraAngle.z = 0;

        transform.eulerAngles = CameraAngle;
    }
}
