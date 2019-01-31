using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows player input to drive around the track
public class PlayerMovement : MonoBehaviour {
    private float _speed = 3.0f, _horizontalInput = 0.0f, _verticalInput = 0.0f;
    private Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _rigidbody.transform.Rotate(new Vector3(0.0f, _horizontalInput * _speed, 0.0f));
        _rigidbody.transform.Translate(new Vector3(0.0f, 0.0f, _verticalInput) * _speed * Time.deltaTime);
	}
}