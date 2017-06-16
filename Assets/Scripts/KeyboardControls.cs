using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyboardControls : MonoBehaviour {

	public float speed;
	private CharacterController cc;
	private float gravity = -9.8f;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {
		float horizontal, vertical;
		horizontal = Input.GetAxis ("Horizontal") * speed;
		vertical = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (-horizontal, 0, -vertical);

		movement = Vector3.ClampMagnitude (movement, speed);

		movement *= Time.deltaTime;
		movement.y = gravity;
		//movement = transform.TransformDirection (movement);
		cc.Move (movement);
	}
}
