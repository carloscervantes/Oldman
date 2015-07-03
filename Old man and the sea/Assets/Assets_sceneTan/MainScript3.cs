using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript3 : MonoBehaviour {
	
	public GameObject fish_atun;
	public GameObject fish_hook;
	public GameObject fish_player;
	public float gridX = 10f;
	public float gridY = 3f;
	public float spacing = 1f;
	//private Bounds[] bbounds;
	private int lifetime = 20; 
	public Text text_numfishes;

	private int fishes_consumed;


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

		//Mandar peces de izquierda 
		StartCoroutine(sendFishes());
		//Mandar peces de derecha
		StartCoroutine(sendFishes2());

	}
	
	
	// Update is called once per frame
	void Update () {

		if (fishes_consumed >= 10 && fishes_consumed < 20) {
			anim_fish.SetInteger ("size", 1); //Young

		}
		if (fishes_consumed >= 20 && fishes_consumed < 30) {
			anim_fish.SetInteger ("size", 2); //Medium

		}
		if (fishes_consumed >= 30) {
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
			generate_fishes(true, -30);
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(6.5F); 
		}
	}


	//Peces Derecha
	IEnumerator sendFishes2() 
	{
		int i = 0;
		while (i <= 10) {
			generate_fishes(false, 50);
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(6.5F); 
		}
	}
		


	void generate_fishes(bool direction, float initial_x_pont){
		for (int x = 0; x < gridX; x++) {
			for (int y = -20; y < gridY; y++) {
				
				Vector3 pos = new Vector3 (initial_x_pont - (x + Random.Range (-5, 6) ), y + Random.Range (-2, 2), 0) * spacing;
				
				int random_kind_of_fish = Random.Range(0,2);
				switch (random_kind_of_fish) 
				{
				case 0:
					// Instantiate the  game object. Atun
					GameObject go0 = (GameObject) Instantiate(fish_atun, pos, Quaternion.identity);
					go0.GetComponent<FishScript_anim>().setinitualdirection(direction);
					go0.GetComponent<FishScript_anim>().setkind_of_fish(random_kind_of_fish);
					Destroy(go0, lifetime);
					break;
				case 1:
					// Instantiate the  game object. Hook
					GameObject go1 = (GameObject) Instantiate(fish_hook, pos, Quaternion.identity);
					go1.GetComponent<FishScript_anim>().setinitualdirection(direction);
					go1.GetComponent<FishScript_anim>().setkind_of_fish(random_kind_of_fish);
					Destroy(go1, lifetime);
					break;
				}
				
			}
		}
	}

	public void increment_fishes_consumed()
	{
		fishes_consumed ++;
		text_numfishes.text = fishes_consumed.ToString();
	}

		
	}
	