using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript3 : MonoBehaviour {
	
	public GameObject fish_atun;
	public GameObject fish_hook;
	public GameObject fish_shark;
	public GameObject fish_player;
	public GameObject camera1;
	public GameObject camera2;
	public GameObject VidSequence;
	public Scrollbar barfishes;
	private float atun_gridX = 10f;
	private float atun_gridY = 2f;
	private float atun_spacing = 1.0f;
	private float hook_gridX = 1f;
	private float hook_gridY = 1f;
	private float hook_spacing = 0.5f;
	private float shark_gridX = 1f;
	private float shark_spacing = 1.5f;
	private int num_to_young = 10;
	private int num_to_medium = 20;
	private int num_to_big = 30;
	private int num_lives = 1;

	//private Bounds[] bbounds;
	private int lifetime = 20; 
	private int lifetime_sharks = 25; 

	public Text text_numfishes;
	public Text text_result;

	private int fishes_consumed;
	private string fish_size;

	private BoxCollider2D coll;


	private Animator anim_fish; 
	private Animator anim_vids;

	// Use this for initialization
	void Start () {
		//Conseguir el animator del pez del jugador
		anim_fish = fish_player.gameObject.GetComponent<Animator> ();
		anim_vids = VidSequence.gameObject.GetComponent<Animator> ();
		//Establecer la talla inicial del pez.
		anim_fish.SetInteger ("size", 0); //Small
		anim_vids.SetInteger ("size", 0); //Small
		//Collider del pez del jugador
		coll = fish_player.gameObject.GetComponent<BoxCollider2D>();

		barfishes.value = 0;
		fishes_consumed = 0;
		text_numfishes.text = "0";

		//Comenzar mandando peces pequenos
		fish_atun.gameObject.transform.localScale = new Vector3(0.4F, 0.4F, 0);
		fish_hook.gameObject.transform.localScale = new Vector3(0.4F, 0.4F, 0);


		//Mandar peces de izquierda 
		StartCoroutine(sendFishes());
		//Mandar peces de derecha
		StartCoroutine(sendFishes2());
		//Mandar los tiburones
		StartCoroutine (sendSharks ());


		//Poblar con peces cercanos mientras llegan los peces generados por la subrutina
		generate_fishes_atun(true, -10);
		generate_fishes_hook(true, -10);
		generate_fishes_atun(false, 10);
		generate_fishes_hook(false, 10);


	}
	
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo vidsstate = anim_vids.GetCurrentAnimatorStateInfo (0);

		if (fishes_consumed < num_to_young) {
			fish_size = "small";
			//anim_fish.SetInteger ("size", 0); //Small - By default 
			fish_atun.gameObject.transform.localScale = new Vector3(0.4F, 0.4F, 0);
			fish_hook.gameObject.transform.localScale = new Vector3(0.4F, 0.4F, 0);

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
			anim_vids.SetInteger ("size", 1); //Young
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

			//Cabiar la distancia a la que se alejan los peces del pez del jugador
			FishScript_anim.mindis = 2.5f;
		}

		if (fishes_consumed >= num_to_medium && fishes_consumed < num_to_big) {
			fish_size = "medium";
			anim_fish.SetInteger ("size", 2); //Medium
			anim_vids.SetInteger ("size", 2); //Medium-Adult
			//fish_atun.gameObject.transform.localScale = new Vector3(0.7F, 0.7F, 0);
			//fish_hook.gameObject.transform.localScale = new Vector3(0.7F, 0.7F, 0);

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

			//Cabiar la distancia a la que se alejan los peces del pez del jugador
			FishScript_anim.mindis = 2.8f;

		}
		if (fishes_consumed >= num_to_big) {
			fish_size = "big";
			anim_fish.SetInteger ("size", 3); //Big
			anim_vids.SetInteger ("size", 3); //Big
			anim_fish.gameObject.transform.localScale = new Vector3(2F, 2F, 0);
			//fish_atun.gameObject.transform.localScale = new Vector3(1.1F, 1.1F, 0);
			//fish_hook.gameObject.transform.localScale = new Vector3(1.1F, 1.1F, 0);

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

			//Cabiar la distancia a la que se alejan los peces del pez del jugador
			FishScript_anim.mindis = 3.0f;
		}


		if (vidsstate.IsName ("EndGameCatched")) 
		{
			//camera1.gameObject.SetActive (true);
			//camera2.gameObject.SetActive (false);
			Application.LoadLevel(5);

		}
		if (vidsstate.IsName ("EndGameFree")) 
		{
			camera1.gameObject.SetActive (true);
			camera2.gameObject.SetActive (false);

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
		

	IEnumerator sendSharks() 
	{
		int i = 0;
		while (i <= 10) {
			generate_fishes_shark(false, 30);
			generate_fishes_shark(true, -30);
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(10F); 
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


	void generate_fishes_shark(bool direction, float initial_x_pont){
		for (int x = 0; x < shark_gridX; x++) {
				Vector3 pos = new Vector3 (initial_x_pont - (x + Random.Range (-5, 6) ), 0 + Random.Range (-2, 2), 0) * shark_spacing;
				
				// Instantiate the  game object. Hook
				GameObject go1 = (GameObject) Instantiate(fish_shark, pos, Quaternion.identity);
				go1.GetComponent<FishScript_anim>().setinitualdirection(direction);
				go1.GetComponent<FishScript_anim>().setkind_of_fish(2);
				Destroy(go1, lifetime_sharks);
		}
	}

	public void increment_fishes_consumed()
	{
		fishes_consumed ++;
		barfishes.value = barfishes.value + 0.03f;
		text_numfishes.text = fishes_consumed.ToString();

		if (barfishes.value >= 1) 
		{
			Application.LoadLevel (7);
		}

	}

	public void catched_fish()
	{
		num_lives--;
		//Debug.Log (num_lives);
		if (num_lives == 0) 
		{
			//You died
			//before
			//text_result.gameObject.SetActive (true);
			//text_result.text = "You die...";
			//Wait 5 seconds and restart the game
			//StartCoroutine(die_restart_game());

			anim_vids.SetTrigger ("result_catched");

		}
	}

	public void saved_fish()
	{
		anim_vids.SetTrigger ("result_free");
	}

	IEnumerator die_restart_game() 
	{

		yield return new WaitForSeconds(5F); 
		//after waiting, It decides who is the winner;
		Application.LoadLevel (0);
	}


	public void fight()
	{
		anim_vids.SetTrigger ("startfight");
		camera2.gameObject.SetActive (true);
		camera1.gameObject.SetActive (false);


	}

	}
	