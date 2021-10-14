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
	private float halfHoleSize;
	private float spawnDelay = 3f;

	void Start()
	{
		sizeX = ReferenceFloor.localScale.x;
		cellSize = sizeX / Partition;
		halfHoleSize = 1.5f * FindObjectOfType<Player>().transform.localScale.x * cellSize / 2;

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
	    var holesAmount = Random.Range(1, 4);

	    var positionOffset = spawnPoint.transform.position;

	    var point = Random.Range(1, Partition - 1);
	    CreateCell(cellSize * point - halfHoleSize, positionOffset);
	    positionOffset.x += cellSize * point + halfHoleSize;
	    var lastPoint = point;

	    for (var i = 0; i < holesAmount - 1; ++i) {
		    if (lastPoint + 1 >= Partition - 1) {
			    break;
		    }

		    point = Random.Range(lastPoint + 1, Partition - 1);
		    var distance = point - lastPoint;
		    CreateCell(cellSize * distance - halfHoleSize, positionOffset);
		    positionOffset.x += cellSize * distance + halfHoleSize;
		    lastPoint = point;
	    }
	    
		CreateCell(cellSize * (Partition - lastPoint) - halfHoleSize, positionOffset);
    }

    private void CreateCell(float xSize, Vector3 positionOffset)
    {
	    var cell = Instantiate(FloorCell, cellHolder);
	    cell.transform.parent = cellHolder;
	    cell.transform.localScale = new Vector3(xSize, 1f);
	    cell.transform.position = positionOffset + new Vector3(xSize / 2, 0);
    }
}
