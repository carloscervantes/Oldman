using UnityEngine;
using System.Collections;

public class PlayerFishScript22 : MonoBehaviour {

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
	Animator anim;

	
	// Use this for initialization
	void Start () {
		//_fishgravity = GameObject.Find("Fish").GetComponent<fishgravity>();	
		anim = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		mouseposition = Input.mousePosition;
		mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
		transform.position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
		
		if (Input.GetMouseButton(0)){
			moveSpeed = fishTopSpeed;
		} else moveSpeed = 0.04f;


		anim.SetFloat ("xdirection", Input.GetAxis("Mouse X"));
		anim.SetFloat ("ydirection", Input.GetAxis("Mouse Y"));
		//if (mouseposition.x)
		//Debug.Log (mouseposition.x);
		//Debug.Log (Input.GetAxis("Mouse X"));

		//Debug.Log (this.gameObject.transform.position.x);


		/*
		if(Input.GetAxis("Mouse X") >= 1f){
			//play animation for left move
			//transform.eulerAngles = new Vector3(0,180,0);
			this.gameObject.transform.Rotate(new Vector3(0,180,0));
			//Debug.Log("alalalala");
		}
		if(Input.GetAxis("Mouse X") < -1f ){
			//play animation for right move
			//transform.eulerAngles = new Vector3(0,0,0);
			this.gameObject.transform.Rotate(new Vector3(0,0,0));
		}
*/

		//transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);



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

		if (coll.collider.gameObject.tag == "fish") {
			//Debug.Log (coll.collider.gameObject.name);
			Destroy (coll.collider.gameObject, 0);
		}

		if (coll.collider.gameObject.tag == "limits") {
			Debug.Log (coll.collider.gameObject.name);
			//Destroy (coll.collider.gameObject, 0);
		}
		
	}




}
