using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public Vector2 StartingSpeed = new Vector2(200f, 800f);
	public Vector2 Acceleration = new Vector2(200f, -800f);
	public Vector2 SpeedLimit = new Vector2(800f, -400f);

	private Vector2 Speed;
	private Vector2 movementVector;
	private Camera mainCamera;

	void Start()
	{
		mainCamera = FindObjectOfType<Camera>();
		Speed = StartingSpeed;
	}

    void Update()
    {
	    movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
	    if (movementVector != Vector2.zero) {
		    Speed += Acceleration * new Vector2(Mathf.Abs(movementVector.x), Mathf.Abs(movementVector.y)) * Time.fixedDeltaTime;
		    Speed = new Vector2(
			    Mathf.Clamp(Speed.x, StartingSpeed.x, SpeedLimit.x),
			    Mathf.Clamp(Speed.y, StartingSpeed.y, SpeedLimit.y)
			);
		    GetComponent<Rigidbody2D>().velocity = (movementVector * Speed + new Vector2(0f, -Globals.Gravity)) * Time.fixedDeltaTime;
	    }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.CompareTag("GC")) {
		    FindObjectOfType<GameManager>().StopPlaying();
			FindObjectOfType<SceneLoader>().LoadScene(SceneLoader.Scenes.EndScreen);
	    }
    }
}
