using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float Speed = 200f;

	private Vector2 movementVector;
	private Camera camera;

	void Start()
	{
		camera = FindObjectOfType<Camera>();
	}

    void Update()
    {
	    movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

	    if (camera.WorldToViewportPoint(transform.position).y > 1)
	    {
		    SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.EndScreen));
		}
	}

    void FixedUpdate()
    {
	    if (movementVector != Vector2.zero) {
		    var rigidbody = GetComponent<Rigidbody2D>();
		    rigidbody.velocity = (movementVector * Speed + new Vector2(0f, -Globals.Gravity)) * Time.fixedDeltaTime;
	    }
    }
}
