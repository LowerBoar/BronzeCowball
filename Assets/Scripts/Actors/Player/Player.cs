using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float HorizontalSpeed = 200f;
	public float VerticalSpeed = 400f;

	private Vector2 Speed;
	private Vector2 movementVector;
	private Camera camera;

	void Start()
	{
		camera = FindObjectOfType<Camera>();
		Speed = new Vector2(HorizontalSpeed, VerticalSpeed);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.CompareTag("GC")) {
		    FindObjectOfType<GameManager>().StopPlaying();
			SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.EndScreen));    // TODO Maybe this better lie in SceneManager?
	    }
    }
}
