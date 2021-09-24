using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
	public void Awake()
	{
		FindObjectOfType<GameManager>().BeginPlaying();
		SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.GameScreen));
	}
}