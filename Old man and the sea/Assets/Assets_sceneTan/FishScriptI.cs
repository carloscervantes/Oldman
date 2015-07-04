using UnityEngine;
using System.Collections;

public class FishScriptI : MonoBehaviour {
	
	private bool initialdirection = false;
	private bool direction = false;
	
	private float count = 0.0f;
	private float speed = 10.0f;
	private float timingOffset = 1.0f;
	private float height = 0.1f;
	
	private float lala;
	
	public GameObject playerfish;
	public float mindis = 4.10f;
	
	private float dis;
	
	
	// Use this for initialization
	void Start () {
		lala = Random.Range(-0.1f, 0.1f);
		height = Random.Range(0.1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime / Random.Range(50, 60);
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
			direction = !initialdirection;
		}
		
	}
	
	
	
	public void setinitualdirection (bool direc){
		initialdirection = direc;
	}
	
	
	
	
	
	
}
