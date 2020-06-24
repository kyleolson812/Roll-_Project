using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPlayerControlledVelocity : MonoBehaviour
{
	public Transform cam;

	[SerializeField]
	Vector3 v3Force;
	[SerializeField]
	KeyCode keyPositive;
	[SerializeField]
	KeyCode keyNegative;

    void FixedUpdate()
    {
		if (Input.GetKey(keyPositive))
		GetComponent<Rigidbody>().velocity += v3Force;

		if (Input.GetKey(keyNegative))
		GetComponent<Rigidbody>().velocity -= v3Force;
    }
}
