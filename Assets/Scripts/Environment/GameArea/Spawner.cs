using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject FloorCell;

	private GameObject spawnPoint;
	private GameObject holder;
	private Camera mainCamera;

	void Start()
	{
		var holder = transform.Find("Cells");
		mainCamera = GetComponentInParent<Camera>();
		var spawnPointSprite = GetComponentInChildren<SpriteRenderer>();

		spawnPoint = spawnPointSprite.gameObject;
		spawnPointSprite.enabled = false;

		var cell = Instantiate(FloorCell, holder);
		cell.transform.position = spawnPoint.transform.position;
		cell.transform.localScale = new Vector3(mainCamera.orthographicSize * 2, 1f);
	}

    void Update()
    {
        
    }
}
