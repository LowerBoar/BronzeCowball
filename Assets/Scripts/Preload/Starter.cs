using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
	public void Awake()
	{
		SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.MainMenu));
	}
}
