using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Keyboard_Mouse_Controls : MonoBehaviour {

	private float speed = 4f;
	private CharacterController cc;
	private float gravity = -9.8f;
	private float rotationX = 0.0f; 
	public float sensitivityHori = 9.0f;
	public float sensitivityVert = 9.0f;
	private float minVert = -30.0f, maxVert = 45.0f; 


	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

		float rotationY, deltaY;							//mouselook code begins

		rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
		rotationX = Mathf.Clamp (rotationX, minVert, maxVert);

		deltaY = Input.GetAxis("Mouse X") * sensitivityHori;
		rotationY = transform.localEulerAngles.y + deltaY;
		transform.localEulerAngles = new Vector3 (-rotationX, rotationY, 0.0f); 		//mouselook code ends


		float horizontal, vertical;														//keyboard movement begins
		horizontal = Input.GetAxis ("Horizontal") * speed;
		vertical = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (-horizontal, 0, -vertical);

		movement = Vector3.ClampMagnitude (movement, speed);
        //MouseLook obj = new MouseLook();
        movement = transform.rotation * movement;
		movement *= Time.deltaTime;
		movement.y = gravity;
		//movement = transform.TransformDirection (movement);
		cc.Move (movement);																//keyboard movement ends



		if (Input.GetKey (KeyCode.LeftControl))									//crouch code begins
			cc.transform.position = new Vector3(cc.transform.position.x, .1f, cc.transform.position.z);
		else
			cc.transform.position = new Vector3(cc.transform.position.x, 1.58f, cc.transform.position.z);												//crouch code ends



		if (Input.GetKey (KeyCode.LeftShift))									//sprint code begins
			speed = 8f;
		else
			speed = 4f;															//sprint code ends

		//if(Input.GetKey(KeyCode.Space))
			


	}
}
