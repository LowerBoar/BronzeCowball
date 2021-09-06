using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject FloorCell;
	private int Partition = 40;

	private GameObject spawnPoint;
	private GameObject holder;
	private float sizeX;

	void Start()
	{
		var holder = transform.Find("Cells");
		sizeX = GetComponentInParent<Camera>().orthographicSize * 2;
		var spawnPointSprite = GetComponentInChildren<SpriteRenderer>();

		spawnPoint = spawnPointSprite.gameObject;
		spawnPointSprite.enabled = false;

		var point = Random.Range(2, Partition - 2);
		var cellSize = sizeX / Partition;

		var cell = Instantiate(FloorCell, holder);
		cell.transform.position =
			spawnPoint.transform.position - new Vector3((Partition / 2 - point - 1) * cellSize, 0);
		cell.transform.localScale = new Vector3(sizeX * point, 1f);	// TODO Scale won't do. Need to think of some other size-control system

		cell = Instantiate(FloorCell, holder);
		cell.transform.position = spawnPoint.transform.position - new Vector3((Partition / 2 - point + 1) * cellSize, 0);
		cell.transform.localScale = new Vector3(sizeX * (Partition - point), 1f);
	}

    void Update()
    {
        
    }
}
