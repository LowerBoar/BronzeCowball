using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public GameObject CrossFade;

	public void LoadScene(Scenes scene)
    {
	    StartCoroutine(LoadSceneTask(scene));
    }

    private IEnumerator LoadSceneTask(Scenes scene)
    {
		CrossFade.SetActive(true);
	    if (scene != Scenes.MainMenu) {
		    CrossFade.GetComponent<Animator>().SetTrigger("In");
		    yield return new WaitForSeconds(1);	// TODO Need to get animation time from animator
	    }

	    SceneManager.LoadScene(GetSceneIndex(scene));

		CrossFade.GetComponent<Animator>().SetTrigger("Out");
		yield return new WaitForSeconds(1);
		CrossFade.SetActive(false);
	}

	public static int GetSceneIndex(Scenes scene) => (int)scene;

    public enum Scenes
    {
	    Preload = 0,
	    MainMenu = 1,
	    GameScreen = 2,
	    EndScreen = 3,
    }
}
