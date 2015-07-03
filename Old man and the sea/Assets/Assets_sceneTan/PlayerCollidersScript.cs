using UnityEngine;
using System.Collections;

public class PlayerCollidersScript : MonoBehaviour {

	public GameObject MainGame;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.collider.gameObject.tag == "fish") {
			//Debug.Log (coll.collider.gameObject.name);
			Destroy (coll.collider.gameObject, 0);
			MainGame.gameObject.GetComponent<MainScript3>().increment_fishes_consumed();
		}
		
		
	}


}
