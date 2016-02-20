using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SEM_CharacterController : MonoBehaviour {

    public List<float> MaxSpeeds;
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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        float speed = Input.GetAxis("Vertical") * MaxSpeeds[0];

        rb.AddForce(transform.forward * speed);
            
	
	}
}
