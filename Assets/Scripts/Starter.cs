using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
	public void Awake()
	{
		SceneManager.LoadScene(1);
	}
}
