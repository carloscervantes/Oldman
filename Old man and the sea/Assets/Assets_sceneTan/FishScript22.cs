using UnityEngine;
using System.Collections;

public class FishScript22 : MonoBehaviour {

	private int yy;
	private int xx;
	private int id;
	private bool direction = true;

	private float count = 0.0f;
	private float speed = 7.0f;
	private float timingOffset = 1.0f;
	private float height = 1.0f;

	private float lala;

	public GameObject playerfish;
	public float mindis = 30;

	private float dis;

	
	// Use this for initialization
	void Start () {
		lala = Random.Range(-25, 26);
		height = Random.Range(1, 2);
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime / Random.Range(10, 20);
		var offset = this.transform.position.y + Mathf.Sin( (Time.time + lala) * speed + timingOffset) * height / 2;
		//transform.position = new Vector3(this.transform.position.x + count, offset, 0);
		if (direction) {
			transform.position = new Vector3( this.transform.position.x  + count, offset, 0);
		} else {
			transform.position = new Vector3( this.transform.position.x  - count, offset, 0);
		}


		dis = Vector3.Distance(this.transform.position, playerfish.gameObject.transform.position);
		//Debug.Log(dis);
		if (dis <= mindis)
		{
			//Follow
			//transform.position += transform.forward * AISpeed * Time.deltaTime;
			//changedirection ();
			//this.gameObject.GetComponent<Rigidbody2D>().AddForce (new Vector2(forceApplied,0));
			direction = false;
			//Debug.Log("allalala");
		}


		//Destroy(gameObject, lifetime);
		//Destroy(gameObject, 20);

	}
	
	void OnMouseDown()
	{
		GetComponent<Renderer>().material.color = new Color(0,255,0);
		Debug.Log (xx + " - " + yy);
		
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
	void changedirection (){
		if (direction) {
			direction = false;
			//Debug.Log("false");
		} else {
			direction = true;
		}
	}







}
