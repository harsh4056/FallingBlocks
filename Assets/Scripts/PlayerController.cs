using UnityEngine;
using System.Collections;

using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour {
	public float speed=2;
	float halfScreenWidhtInWorldUnits=9.5f;
	public event System.Action OnPlayerDeath;
	// Use this for initialization
	void Start () {
		float halfPlayerWidth = transform.localScale.x / 2f;
		halfScreenWidhtInWorldUnits=Camera.main.aspect*Camera.main.orthographicSize-halfPlayerWidth;
	}
	
	// Update is called once per frame
	void Update () { 
		float InputX =CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float velocity = InputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
		if (transform.position.x < -halfScreenWidhtInWorldUnits)
			transform.position = new Vector2 (halfScreenWidhtInWorldUnits, transform.position.y);

	
		if (transform.position.x > halfScreenWidhtInWorldUnits)
			transform.position = new Vector2 (-halfScreenWidhtInWorldUnits, transform.position.y);

	}

	void OnTriggerEnter2D(Collider2D triggerCollider){
		if (triggerCollider.tag == "Falling Block") {
			if (OnPlayerDeath != null)
				OnPlayerDeath ();
			Destroy (gameObject);
		}

}
}