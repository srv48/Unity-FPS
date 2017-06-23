using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Keyboard_Mouse_Controls : MonoBehaviour {

	private float speed = 4f;
	private CharacterController cc;
	private Vector3 gravity;
	private float rotationX = 0.0f; 
	public float sensitivityHori = 9.0f;
	public float sensitivityVert = 9.0f;
	private float minVert = -30.0f, maxVert = 45.0f; 
	private Vector3 movement = Vector3.zero;
	private float jumpSpeed = 200.0f;
	private bool jump = false;


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
		movement = new Vector3 (-horizontal, 0f, -vertical);

		movement = Vector3.ClampMagnitude (movement, speed);
        //MouseLook obj = new MouseLook();
        movement = transform.rotation * movement;							//keyboard movement ends





		//float crouch = cc.transform.position.y;
		if (Input.GetKey (KeyCode.LeftControl)) {									//crouch code begins
			cc.height = -5f;
			//cc.transform.position = new Vector3 (cc.transform.position.x, cc.transform.position.y - 1.5f, cc.transform.position.z);
			//crouch = cc.transform.position.y + 1.5f;
		}
		else
			cc.height = 6f;												//crouch code ends
			//cc.transform.position = new Vector3(cc.transform.position.x, crouch , cc.transform.position.z);
		


		if (Input.GetKey (KeyCode.LeftShift))									//sprint code begins
			speed = 8f;
		else
			speed = 4f;		 												//sprint code ends
		

		if (Input.GetKey (KeyCode.Space) && cc.isGrounded)					//jumping code begins
			jump = true;

		if (cc.isGrounded) {
			gravity.y = 0f;
			if (jump) {
				gravity.y = jumpSpeed;
				jump = false;
			}
		}
		else {
			gravity = new Vector3 (0f, -300f, 0f) * Time.deltaTime;
		}																	//jumping code ends

		movement += gravity;

		cc.Move (movement * Time.deltaTime);	


	}
}
