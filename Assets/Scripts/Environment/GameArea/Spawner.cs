using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject FloorCell;
	public Transform cellHolder;

	private int Partition = 10;

	private GameObject spawnPoint;
	private float sizeX;
	private float spawnDelay = 3f;

	void Start()
	{
		sizeX = GameObject.Find("Border").transform.localScale.x;	// TODO Don't do this at home (and stop doing it in this project)
		var spawnPointSprite = GetComponentInChildren<SpriteRenderer>();

		spawnPoint = spawnPointSprite.gameObject;
		spawnPointSprite.enabled = false;

		Spawn();
		StartCoroutine(SpawnQueue(spawnDelay));
	}

    void Update()
    {
        
    }

    private IEnumerator SpawnQueue(float waitTime)
    {
	    yield return new WaitForSeconds(waitTime);
	    Spawn();
	    StartCoroutine(SpawnQueue(Mathf.Max(waitTime - 0.1f, 1.5f)));
    }

    private void Spawn()
    {
	    var point = Random.Range(2, Partition - 2);
	    var cellSize = sizeX / Partition;

	    var additionalOffset = 1.5f;   // TODO Additional offset should be based on player size

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
