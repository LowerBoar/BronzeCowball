using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateedMovement : MonoBehaviour
{
	public float Acceleration = 0.05f;
	public float StartingSpeed = -0.5f;
	private float currentSpeed;

	void Start()
	{
		currentSpeed = StartingSpeed;
	}

    void Update()
    {
	    currentSpeed -= Acceleration * Time.deltaTime;
    }

	private void FixedUpdate()
	{
		transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0f, currentSpeed, 0f), Time.fixedDeltaTime * 1.5f);
    }
}
