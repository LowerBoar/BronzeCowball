using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float Score { get; private set; } = 0f;

	private GameStates state = GameStates.Idle;

	private void Start()	// Not initializing anything in Start, because it is called on every scene (and we don't want to drop the values)
	{
		
	}

	private void Update()
	{
		switch (state) {
			case GameStates.Idle:
				break;
			case GameStates.Play:
				UpdatePlayState();
				break;
		}
	}

	private void UpdatePlayState()
	{
		Score += Globals.ScoreGain * Time.deltaTime;
	}

	public void BeginPlaying()
	{
		Score = 0f;
		state = GameStates.Play;
	}

	public void StopPlaying()
	{
		state = GameStates.Idle;
	}
}

public enum GameStates
{
	Idle,
	Play,
	Pause,
}
