using UnityEngine;
using System.Collections;
using System;

public class SEM_CameraController : MonoBehaviour {

    public Transform Target;

    public Vector3 CameraAngle = Vector3.zero;

	// Use this for initialization
	void Start () {

        CameraAngle = transform.eulerAngles;
	
	}
	
	// Update is called once per frame
	void Update () {


        CameraAngle = transform.eulerAngles; 

        CameraAngle.z = 0;

        transform.eulerAngles = CameraAngle;
        //TrackAndFollow();

    }

    
}
