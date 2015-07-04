using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollidersScript : MonoBehaviour {

	public GameObject MainGame;
	public Scrollbar bar;

	private bool fight_started;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (fight_started == false) {
			//push up slow
			bar.value = bar.value + 0.001f;

		} else {
			//push randomly hard
			bar.value = bar.value + Random.Range(0.005f, 0.02f);
		}


		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Space))
		{
			bar.value = bar.value - 0.1f;
			fight_started = true;
		}



	}


	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.collider.gameObject.tag == "fish") {
			//Debug.Log (coll.collider.gameObject.name);
			Destroy (coll.collider.gameObject, 0);
			MainGame.gameObject.GetComponent<MainScript3>().increment_fishes_consumed();
		}
		if (coll.collider.gameObject.tag == "hook") {
			//Debug.Log (coll.collider.gameObject.name);
			Destroy (coll.collider.gameObject, 0);

			bar.gameObject.SetActive(true);
			bar.value = 0.0f;
			fight_started = false;
			StartCoroutine (time_figthing ());
		}
		
		
	}



	IEnumerator time_figthing() 
	{
		//before
		yield return new WaitForSeconds(10F); 
		//after waiting, It decides who is the winner.
		if (bar.value <= 0.5) {
			Debug.Log("fish saved");
		} else {
			Debug.Log("fish hooked");
			this.gameObject.SetActive(false);
		}
		bar.gameObject.SetActive(false);
		//Informt to the main game the result of the fight when hooked
		MainGame.gameObject.GetComponent<MainScript3>().catched_fish();
	}



}
