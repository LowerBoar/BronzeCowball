using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public GameObject FloorCell;
	private int Partition = 10;

	private GameObject spawnPoint;
	private Transform holder;
	private float sizeX;

	void Start()
	{
		holder = transform.Find("Cells");
		sizeX = GetComponentInParent<Camera>().orthographicSize * 2;
		var spawnPointSprite = GetComponentInChildren<SpriteRenderer>();

		spawnPoint = spawnPointSprite.gameObject;
		spawnPointSprite.enabled = false;

		InvokeRepeating(nameof(Spawn), 0f, 3f);
	}

    void Update()
    {
        
    }

    private void Spawn()
    {
	    var point = Random.Range(2, Partition - 2);
	    var cellSize = sizeX / Partition;

	    var additionalOffset = 1.5f;   // TODO Additional offset should be based on player size

	    var cell = Instantiate(FloorCell, holder);
	    var size = new Vector3(cellSize * point, 1f);
	    cell.transform.localScale = size;
	    cell.transform.position =
		    spawnPoint.transform.position + new Vector3(size.x / 2 + sizeX / 2, 0);

	    var sizeSum = size.x;

	    cell = Instantiate(FloorCell, holder);
		size = new Vector3(cellSize * (Partition - point), 1f);
		cell.transform.localScale = size;
		cell.transform.position = spawnPoint.transform.position + new Vector3(size.x / 2 + sizeX / 2 + sizeSum + additionalOffset * cellSize, 0);	// TODO Replace this ugly code with something clean
	}
}
