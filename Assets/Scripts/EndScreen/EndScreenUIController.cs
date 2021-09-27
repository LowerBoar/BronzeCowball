using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenUIController : MonoBehaviour
{
	void Start()
	{
		GetComponentInChildren<Text>().text = 
			Math.Round(FindObjectOfType<GameManager>().Score, 1).ToString(CultureInfo.InvariantCulture);

		GetComponentInChildren<Button>().onClick.AddListener(OnReplayButtonClick);
	}

	private void OnReplayButtonClick()
	{
		FindObjectOfType<GameManager>().BeginPlaying();
		SceneManager.LoadScene(Globals.GetSceneIndex(Globals.Scenes.GameScreen));
	}
}
