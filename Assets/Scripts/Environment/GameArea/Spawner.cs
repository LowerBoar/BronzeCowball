using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject FloorCell;
	public Transform cellHolder;
	public Transform ReferenceFloor;

	private int Partition = 10;

	private GameObject spawnPoint;
	private float sizeX;
	private float cellSize;
	private float holeSize;
	private float spawnDelay = 3f;

	void Start()
	{
		sizeX = ReferenceFloor.localScale.x;
		cellSize = sizeX / Partition;
		holeSize = 1.5f * FindObjectOfType<Player>().transform.localScale.x * cellSize;

		var spawnPointSprite = GetComponentInChildren<SpriteRenderer>();

		spawnPoint = spawnPointSprite.gameObject;
		spawnPointSprite.enabled = false;

		Spawn();
		StartCoroutine(SpawnQueue(spawnDelay));
	}

	private IEnumerator SpawnQueue(float waitTime)
    {
	    while (true) {
		    yield return new WaitForSeconds(waitTime);
		    waitTime = Mathf.Max(waitTime - 0.1f, 1f);
		    Spawn();
	    }
    }

    private void Spawn()
    {
	    var positionOffset = spawnPoint.transform.position;
	    var point = Random.Range(2, Partition - 2);

		CreateCell(cellSize * point - holeSize / 2, positionOffset);
		positionOffset.x += cellSize * point + holeSize / 2;
		
		CreateCell(cellSize * (Partition - point) - holeSize / 2, positionOffset);
    }

    private void CreateCell(float xSize, Vector3 positionOffset)
    {
	    var cell = Instantiate(FloorCell, cellHolder);
	    cell.transform.parent = cellHolder;
	    cell.transform.localScale = new Vector3(xSize, 1f);
	    cell.transform.position = positionOffset + new Vector3(xSize / 2, 0);
    }
}
