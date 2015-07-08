using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript3 : MonoBehaviour {
	
	public GameObject fish_atun;
	public GameObject fish_hook;
	public GameObject fish_player;
	private float atun_gridX = 10f;
	private float atun_gridY = 2f;
	private float atun_spacing = 0.5f;
	private float hook_gridX = 5f;
	private float hook_gridY = 1f;
	private float hook_spacing = 0.5f;
	private int num_to_young = 5;
	private int num_to_medium = 10;
	private int num_to_big = 15;
	private int num_lives = 1;

	//private Bounds[] bbounds;
	private int lifetime = 20; 
	public Text text_numfishes;
	public Text text_result;

	private int fishes_consumed;
	private string fish_size;

	private BoxCollider2D coll;


	private Animator anim_fish; 

	// Use this for initialization
	void Start () {
		//Conseguir el animator del pez del jugador
		anim_fish = fish_player.gameObject.GetComponent<Animator> ();
		//Establecer la talla inicial del pez.
		anim_fish.SetInteger ("size", 0); //Small
		//Collider del pez del jugador
		coll = fish_player.gameObject.GetComponent<BoxCollider2D>();

		fishes_consumed = 0;
		text_numfishes.text = "0";

		//Comenzar mandando peces pequenos
		fish_atun.gameObject.transform.localScale = new Vector3(0.3F, 0.3F, 0);
		fish_hook.gameObject.transform.localScale = new Vector3(0.3F, 0.3F, 0);


		//Mandar peces de izquierda 
		StartCoroutine(sendFishes());
		//Mandar peces de derecha
		StartCoroutine(sendFishes2());

	}
	
	
	// Update is called once per frame
	void Update () {

		if (fishes_consumed < num_to_young) {
			fish_size = "small";
			//anim_fish.SetInteger ("size", 0); //Small - By default 
			fish_atun.gameObject.transform.localScale = new Vector3(0.3F, 0.3F, 0);
			fish_hook.gameObject.transform.localScale = new Vector3(0.3F, 0.3F, 0);

			if (Input.GetKey(KeyCode.RightArrow))
			{
			coll.size = new Vector2(0.5f, 0.5f);
			coll.offset = new Vector2(0.25f,0f);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				coll.size = new Vector2(0.5f, 0.5f);
				coll.offset = new Vector2(-0.25f,0f);
			}

		}

		if (fishes_consumed >= num_to_young && fishes_consumed < num_to_medium) {
			fish_size = "young";
			anim_fish.SetInteger ("size", 1); //Young
			fish_atun.gameObject.transform.localScale = new Vector3(0.6F, 0.6F, 0);
			fish_hook.gameObject.transform.localScale = new Vector3(0.6F, 0.6F, 0);

			if (Input.GetKey(KeyCode.RightArrow))
			{
				coll.size = new Vector2(0.7f, 0.7f);
				coll.offset = new Vector2(0.7f,0f);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				coll.size = new Vector2(0.7f, 0.7f);
				coll.offset = new Vector2(-0.7f,0f);
			}
		}

		if (fishes_consumed >= num_to_medium && fishes_consumed < num_to_big) {
			fish_size = "medium";
			anim_fish.SetInteger ("size", 2); //Medium
			fish_atun.gameObject.transform.localScale = new Vector3(0.7F, 0.7F, 0);
			fish_hook.gameObject.transform.localScale = new Vector3(0.7F, 0.7F, 0);

			if (Input.GetKey(KeyCode.RightArrow))
			{
				coll.size = new Vector2(0.7f, 0.7f);
				coll.offset = new Vector2(1f,0f);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				coll.size = new Vector2(0.7f, 0.7f);
				coll.offset = new Vector2(-1f,0f);
			}

		}
		if (fishes_consumed >= num_to_big) {
			fish_size = "big";
			anim_fish.SetInteger ("size", 3); //Big
			anim_fish.gameObject.transform.localScale = new Vector3(2F, 2F, 0);
			fish_atun.gameObject.transform.localScale = new Vector3(1.1F, 1.1F, 0);
			fish_hook.gameObject.transform.localScale = new Vector3(1.1F, 1.1F, 0);

			if (Input.GetKey(KeyCode.RightArrow))
			{
				coll.size = new Vector2(0.7f, 0.7f);
				coll.offset = new Vector2(1f,0f);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				coll.size = new Vector2(0.7f, 0.7f);
				coll.offset = new Vector2(-1f,0f);
			}
		}


	}
	
	public void check(int id)
	{
		//		int k = bbounds.GetLength();
		
	}
	
	IEnumerator MyMethod() {
		//Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(5);
		//Debug.Log("After Waiting 2 Seconds");
	}

	//Peces Izquierda
	IEnumerator sendFishes() 
	{
		int i = 0;
		while (i <= 10) 
		{
			generate_fishes_atun(true, -70);
			generate_fishes_hook(true, -70);
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(5F); 
		}
	}


	//Peces Derecha
	IEnumerator sendFishes2() 
	{
		int i = 0;
		while (i <= 10) {
			generate_fishes_atun(false, 70);
			generate_fishes_hook(false, 70);
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(5F); 
		}
	}
		


	void generate_fishes_atun(bool direction, float initial_x_pont){
		for (int x = 0; x < atun_gridX; x++) {
			for (int y = 0; y < atun_gridY; y++) {
				
				Vector3 pos = new Vector3 (initial_x_pont - (x + Random.Range (-5, 6) ), 0 + Random.Range (-2, 2), 0) * atun_spacing;

					// Instantiate the  game object. Atun
					GameObject go0 = (GameObject) Instantiate(fish_atun, pos, Quaternion.identity);
					go0.GetComponent<FishScript_anim>().setinitualdirection(direction);
					go0.GetComponent<FishScript_anim>().setkind_of_fish(0);
					Destroy(go0, lifetime);
			}
		}
	}


	void generate_fishes_hook(bool direction, float initial_x_pont){
		for (int x = 0; x < hook_gridX; x++) {
			for (int y = 0; y < hook_gridY; y++) {
				
				Vector3 pos = new Vector3 (initial_x_pont - (x + Random.Range (-5, 6) ), 0 + Random.Range (-2, 2), 0) * hook_spacing;
					
					// Instantiate the  game object. Hook
					GameObject go1 = (GameObject) Instantiate(fish_hook, pos, Quaternion.identity);
					go1.GetComponent<FishScript_anim>().setinitualdirection(direction);
					go1.GetComponent<FishScript_anim>().setkind_of_fish(1);
					Destroy(go1, lifetime);
			}
		}
	}

	public void increment_fishes_consumed()
	{
		fishes_consumed ++;
		text_numfishes.text = fishes_consumed.ToString();
	}

	public void catched_fish()
	{
		num_lives--;
		Debug.Log (num_lives);
		if (num_lives == 0) 
		{
			//You died
			//Wait 5 seconds and restart the game
			StartCoroutine(die_restart_game());
		}
	}



	IEnumerator die_restart_game() 
	{
		//before
		text_result.gameObject.SetActive (true);
		text_result.text = "You die...";
		yield return new WaitForSeconds(5F); 
		//after waiting, It decides who is the winner;
		Application.LoadLevel (0);
	}


	}
	