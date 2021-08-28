using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float Speed = 200f;

	private Vector2 movementVector;

	void Start()
    {
        
    }

    void Update()
    {
	    movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
	    if (movementVector != Vector2.zero) {
		    var rigidbody = GetComponent<Rigidbody2D>();
		    rigidbody.velocity = (movementVector * Speed + new Vector2(0f, -Globals.Gravity)) * Time.fixedDeltaTime;
	    }
    }
}
