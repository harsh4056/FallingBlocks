using UnityEngine;
using System.Collections;

public class FallingBLock : MonoBehaviour {
	public Vector2 speedMinMax;
	float speed ;
	float visibleHeightThreshold;
	// Use this for initialization
	void Start () {
		speed = Mathf.Lerp (speedMinMax.y, speedMinMax.x, Difficulty.GetDifficultyPercent ());
		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector2.down * speed * Time.deltaTime);
		if (transform.position.y < visibleHeightThreshold) {
			Destroy (gameObject);
		}
	}
}
