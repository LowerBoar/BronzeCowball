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
	private float spawnDelay = 3f;

	void Start()
	{
		sizeX = ReferenceFloor.localScale.x;
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
	    var point = Random.Range(2, Partition - 2);
	    var cellSize = sizeX / Partition;

	    var additionalOffset = 1.5f * FindObjectOfType<Player>().transform.localScale.x;

	    var cell = Instantiate(FloorCell, cellHolder);
	    cell.transform.parent = cellHolder;
	    var size = new Vector3(cellSize * point - additionalOffset * cellSize / 2, 1f);
	    cell.transform.localScale = size;
	    cell.transform.position =
		    spawnPoint.transform.position + new Vector3(size.x / 2, 0);

	    var sizeSum = size.x;

	    cell = Instantiate(FloorCell, cellHolder);
	    cell.transform.parent = cellHolder;
		size = new Vector3(cellSize * (Partition - point) - additionalOffset * cellSize / 2, 1f);
		cell.transform.localScale = size;
		cell.transform.position = spawnPoint.transform.position + new Vector3(size.x / 2 + sizeSum + additionalOffset * cellSize, 0);	// TODO Replace this ugly code with something clean
    }
}
