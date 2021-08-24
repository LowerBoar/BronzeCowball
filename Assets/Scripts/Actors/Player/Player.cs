using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
		    rigidbody.MovePosition(rigidbody.position + movementVector * Time.fixedDeltaTime);  // TODO Cancels gravity. Should we apply it by ourselves?
        }
    }
}
