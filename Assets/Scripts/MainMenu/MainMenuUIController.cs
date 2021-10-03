using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
	public AudioClip PlayButtonClickSound;

	void Start()
    {
        GetComponentInChildren<Button>().onClick.AddListener(OnPlayButtonClick);
    }

	private void OnPlayButtonClick()
	{
		var audioSource = GetComponent<AudioSource>();	// TODO Move this to SoundManager
		audioSource.clip = PlayButtonClickSound;
		audioSource.Play();

	    FindObjectOfType<GameManager>().BeginPlaying();
	    SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.GameScreen));
    }
}
