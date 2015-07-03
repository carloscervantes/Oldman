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
	private float hook_gridX = 1f;
	private float hook_gridY = 1f;
	private float hook_spacing = 0.5f;

	//private Bounds[] bbounds;
	private int lifetime = 20; 
	public Text text_numfishes;

	private int fishes_consumed;
	private string fish_size;


	private Animator anim_fish; 

	// Use this for initialization
	void Start () {
		//Conseguir el animator del pez del jugador
		anim_fish = fish_player.gameObject.GetComponent<Animator> ();
		//Establecer la talla inicial del pez.
		anim_fish.SetInteger ("size", 0); //Small
		//
		fishes_consumed = 0;
		text_numfishes.text = "0";
		//

		fish_size = "small";
		anim_fish.SetInteger ("size", 0); //Small

	//	fish_size = "medium";
	//	anim_fish.SetInteger ("size", 2); //

		//Mandar peces de izquierda 
		StartCoroutine(sendFishes());
		//Mandar peces de derecha
		StartCoroutine(sendFishes2());

	}
	
	
	// Update is called once per frame
	void Update () {


		if (fishes_consumed >= 10 && fishes_consumed < 20) {
			fish_size = "young";
			anim_fish.SetInteger ("size", 1); //Young
		}
		if (fishes_consumed >= 20 && fishes_consumed < 30) {
			fish_size = "medium";
			anim_fish.SetInteger ("size", 2); //Medium

		}
		if (fishes_consumed >= 30) {
			fish_size = "big";
			anim_fish.SetInteger ("size", 3); //Big
			
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
			/*
			switch (fish_size)
			{
			case "small": 
				fish_atun.gameObject.transform.localScale = new Vector3(0.2F, 0.2F, 0);
				break;
			case "young": 
				fish_atun.gameObject.transform.localScale = new Vector3(0.5F, 0.5F, 0);
				break;
			case "medium": 
				fish_atun.gameObject.transform.localScale = new Vector3(1F, 1F, 0);
				break;
			case "big": 
				fish_atun.gameObject.transform.localScale = new Vector3(1.5F, 1.5F, 0);
				break;
			}
			switch (fish_size)
			{
			case "small": 
				fish_hook.gameObject.transform.localScale = new Vector3(0.2F, 0.2F, 0);
				break;
			case "young": 
				fish_hook.gameObject.transform.localScale = new Vector3(0.5F, 0.5F, 0);
				break;
			case "medium": 
				fish_hook.gameObject.transform.localScale = new Vector3(1F, 1F, 0);
				break;
			case "big": 
				fish_hook.gameObject.transform.localScale = new Vector3(1.5F, 1.5F, 0);
				break;
			}
			*/
			generate_fishes_atun(true, -65);
			generate_fishes_hook(true, -65);
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(7F); 
		}
	}


	//Peces Derecha
	IEnumerator sendFishes2() 
	{
		int i = 0;
		while (i <= 10) {
			generate_fishes_atun(false, 60);
			generate_fishes_hook(false, 60);
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

		
	}
	