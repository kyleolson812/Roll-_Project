using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement: MonoBehaviour
{
	[SerializeField]
	Vector3 v3Force;
	[SerializeField]
	KeyCode keyPositive;
	[SerializeField]
	KeyCode keyNegative;
	
	//public CharacterController controller;
	public Transform cam;
	public float speed = 6f;

	void FixedUpdate()
	{
		if (Input.GetKey(keyPositive))
			GetComponent<Rigidbody>().velocity += v3Force;

		if (Input.GetKey(keyNegative))
			GetComponent<Rigidbody>().velocity -= v3Force;
	}
	

    void Update()
	{
		//if (Input.GetKey(keyPositive))
		//GetComponent<Rigidbody>().velocity += v3Force;

		//if (Input.GetKey(keyNegative))
		//GetComponent<Rigidbody>().velocity -= v3Force;

		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

		if(direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			//controller.Move(moveDir.normalized * speed * Time.deltaTime);
		}
    }
}