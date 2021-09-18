using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour    // TODO Maybe we should think about better name
{
    private Camera camera;

    void Start()
    {
	    camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
	    if (camera.WorldToViewportPoint(transform.position).y > 1.5) {  // Give it some time to fully disappear
		    Destroy(gameObject);
	    } 
    }
}
