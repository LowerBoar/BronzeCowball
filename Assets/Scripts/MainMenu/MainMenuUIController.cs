using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
	void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(OnPlayButtonClick);
    }

	private void OnPlayButtonClick()
	{
		var soundManager = FindObjectOfType<SoundManager>();
		soundManager.PlaySound("PlayButtonClick");
		soundManager.PlayMusic("GameScreen");

	    FindObjectOfType<GameManager>().BeginPlaying();
	    SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.GameScreen));
    }
}
