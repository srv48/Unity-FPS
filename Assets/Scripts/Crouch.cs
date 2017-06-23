using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {
	private CharacterController cc2;

	// Use this for initialization
	void Start () {
		cc2 = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftControl))
			cc2.height = -1.0f;
		else
			cc2.height = 2.0f;
		if (Input.GetKey (KeyCode.Space))
			cc2.height = 3.0f;
		
	}
}
