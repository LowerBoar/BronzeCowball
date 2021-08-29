using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
	void FixedUpdate()
    {
	    transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0f, -1f, 0f), Time.fixedDeltaTime * 1.5f);
    }
}
