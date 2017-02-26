using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;
	public GameObject fallingBLockPrefab;
	Vector2 screenHalfSizeWorldUnits;
	public Vector2 spawnMinMax;
	public float spawnAngleMax;
	// Use this for initialization
	void Start () {
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect* Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			float spawnSize = Random.Range (spawnMinMax.x, spawnMinMax.y);
			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y+spawnSize/2);
			GameObject newBlock= (GameObject) Instantiate (fallingBLockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
		}
	}
}
