﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMouseLook : MonoBehaviour {

	private Vector2 mouseLook;
	private Vector2 smoothV;

	[SerializeField]
	private float sensitivty = 5.0f;
	[SerializeField]
	private float smoothing = 2.0f;

	private GameObject Character;

	void Start ()
	{
		Character = this.transform.parent.gameObject;
	}
	
	void Update ()
	{
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		md = Vector2.Scale(md, new Vector2(sensitivty * smoothing, sensitivty * smoothing));

		smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		Character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Character.transform.up);
	}
}
