using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
	public enum RotationAxes
	{
		MouseXandY = 0, MouseX = 1, MouseY = 2
	}

	public RotationAxes ra = RotationAxes.MouseXandY; 
	public float sensitivityHori = 9.0f;
	public float sensitivityVert = 9.0f;

	private float maxVert = 45.0f, minVert = -45.0f;
	private float rotationX = 0.0f;
	// Use this for initialization
	void Start() {
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
			body.freezeRotation = true;
	}
	void FixedUpdate()
	{
		
	}

	
	// Update is called once per frame
	void Update () {
		if (ra == RotationAxes.MouseX)
			transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityHori, 0);
		else if (ra == RotationAxes.MouseY) {

			float rotationY;

			rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			rotationX = Mathf.Clamp (rotationX, minVert, maxVert);

			rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0.0f);
		}
		else {
			float rotationY, deltaY;

			rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
			rotationX = Mathf.Clamp (rotationX, minVert, maxVert);

			deltaY = Input.GetAxis("Mouse X") * sensitivityHori;
			rotationY = transform.localEulerAngles.y + deltaY;
			transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0.0f);	
		}
	
			
		
	}
	//Mathf.clamp


}
