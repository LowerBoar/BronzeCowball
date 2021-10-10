using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene(Scenes scene)
    {
	    SceneManager.LoadScene(GetSceneIndex(scene));
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
