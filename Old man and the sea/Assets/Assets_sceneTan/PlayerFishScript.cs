using UnityEngine;
using System.Collections;

public class PlayerFishScript : MonoBehaviour {

	private int yy;
	private int xx;
	private int id;
	//private bool col = false;

	private Vector3 mouseposition;
	public float moveSpeed = 0.04f;
	public float fishTopSpeed = 0.10f; 
	//private fishgravity _fishgravity;
	//private float angle;
	//private Vector3 object_pos;
	//public Transform target;

	
	
	// Use this for initialization
	void Start () {
		//_fishgravity = GameObject.Find("Fish").GetComponent<fishgravity>();	

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		mouseposition = Input.mousePosition;
		mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
		transform.position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
		
		if (Input.GetMouseButton(0)){
			moveSpeed = fishTopSpeed;
		} else moveSpeed = 0.04f;

		
	}

	void update()
	{
		//Debug.Log (Input.mousePosition);


		//this.gameObject.transform.position = Input.mousePosition;




	}

	void OnMouseDown()
	{
		//GetComponent<Renderer>().material.color = new Color(0,255,0);
		//Debug.Log (xx + " - " + yy);
		
		//Destroy (this.gameObject);
		
		
	}
	
	public void setyy (int y){
		yy = y;
	}
	public void setxx (int x){
		xx = x;
	}
	public void setid (int id){
		id = id;
	}


	void OnCollisionEnter2D(Collision2D coll) {

		//Debug.Log (coll.collider.gameObject.name);
		Destroy (coll.collider.gameObject, 0);
		
	}




}
