using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
	public void Awake()
	{
		FindObjectOfType<SceneLoader>().LoadScene(SceneLoader.Scenes.MainMenu);
	}
}
