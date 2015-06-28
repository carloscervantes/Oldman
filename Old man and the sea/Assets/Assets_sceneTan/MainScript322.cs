using UnityEngine;
using System.Collections;

public class MainScript322 : MonoBehaviour {
	
	public GameObject piece;
	public GameObject piece2;
	public float gridX = 10f;
	public float gridY = 6f;
	public float spacing = 2f;
	public int numSelectors = 5;
	private GameObject[,] selectorArr;
	private float ddd;
	//private Bounds[] bbounds;
	private int id = 0;
	//private int x = 0;
	//private int y = 0;
	private int lifetime = 20; 

	// Use this for initialization
	void Start () {

		//original object invisible
		//piece.SetActive (false);

		StartCoroutine(sendFishes());
		StartCoroutine(sendFishes2());
	}
	
	
	// Update is called once per frame
	void Update () {
		
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

	IEnumerator sendFishes() 
	{
		int i = 0;
		while (i <= 10) 
		{
			
			selectorArr = new GameObject[6,10];
			for (int x = 0; x < gridX; x++) {
				for (int y = 0; y < gridY; y++) {
					
					Vector3 pos = new Vector3(x + Random.Range(-25, 26), y + Random.Range(-25, 26) , 0) * spacing;
					
					// Instantiate the piece game object. Required a explict cast conversion (GameObject)
					GameObject go = (GameObject) Instantiate(piece, pos, Quaternion.identity);
					Destroy(go, lifetime);
					//go.GetComponent<Renderer>().material.color = new Color(0,255,0);
					//GameObject go = (GameObject) Instantiate(piece, pos, new Quaternion(90,90,0,0));
					// Save in the Instantiate the x, y identifications
					//go.GetComponent<FishScript>().setyy(y);
					//go.GetComponent<FishScript>().setxx(x);
					//go.GetComponent<FishScript>().setid(id);
					//selectorArr[y,x] = go;
					
					//bbounds[id] = go.GetComponent<Renderer>().bounds;
					id++;
				}
			}
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds(6.5F); 
			
		}


	}



	IEnumerator sendFishes2() 
	{
		int i = 0;
		while (i <= 10) {
			
			selectorArr = new GameObject[6, 10];
			for (int x = 0; x < gridX; x++) {
				for (int y = 0; y < gridY; y++) {
					
					Vector3 pos = new Vector3 (130 - (x + Random.Range (-25, 26) ), y + Random.Range (-25, 26), 0) * spacing;
					
					// Instantiate the piece2 game object. Required a explict cast conversion (GameObject)
					GameObject go = (GameObject)Instantiate (piece2, pos, Quaternion.identity);
					Destroy(go, lifetime);
					//go.GetComponent<Renderer> ().material.color = new Color (0, 255, 0);
					//GameObject go = (GameObject) Instantiate(piece2, pos, new Quaternion(90,90,0,0));
					// Save in the Instantiate the x, y identifications
					//go.GetComponent<FishScriptI> ().setyy (y);
					//go.GetComponent<FishScriptI> ().setxx (x);
					//go.GetComponent<FishScriptI> ().setid (id);
					//selectorArr [y, x] = go;
					
					//bbounds[id] = go.GetComponent<Renderer>().bounds;
					id++;
				}
			}
			//i ++; // never stop to generate fishes
			yield return new WaitForSeconds (6.5F); 
			
		}
	}
		
		
	}
	