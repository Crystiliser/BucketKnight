using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	[SerializeField]
	private float speed = 10f;

	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update ()
	{
		float translation = Input.GetAxis("Vertical") * speed;
		float straffe = Input.GetAxis("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate(straffe, 0, translation);

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked)? CursorLockMode.None : CursorLockMode.Locked;
			print(Cursor.lockState);
		}
	}
}
