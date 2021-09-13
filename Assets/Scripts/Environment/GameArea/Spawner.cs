using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject FloorCell;
	private int Partition = 10;

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

		var additionalOffset = 2;	// TODO Additional offset should be based on player size

		var cell = Instantiate(FloorCell, holder);
		cell.transform.position =
			spawnPoint.transform.position - new Vector3(((float)point / 2 + additionalOffset) * cellSize, 0);
		cell.transform.localScale = new Vector3(cellSize * point, 1f);

		cell = Instantiate(FloorCell, holder);
		cell.transform.position = spawnPoint.transform.position + new Vector3((float)(Partition - point) / 2 * cellSize, 0);
		cell.transform.localScale = new Vector3(cellSize * (Partition - point), 1f);
	}

    void Update()
    {
        
    }
}
