using UnityEngine;
using System.Collections;

public class FishScript_anim : MonoBehaviour {
	
	private bool initialdirection;
	private bool direction;
	
	private float count = 0.0f;
	private float speed = 10.0f;
	private float timingOffset = 1.0f;
	private float height = 0.1f;
	
	private float lala;
	
	public GameObject playerfish;
	private float mindis = 0.10f;
	
	private float dis;
	
	private int kind_of_fish;

	private Animator anim;

	
	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator> ();
		lala = Random.Range(-0.1f, 0.1f);
		height = Random.Range(0.1f, 0.5f);
		
		direction = initialdirection;
		change_animation();
	}
	
	// Update is called once per frame
	void Update () {

		count += Time.deltaTime / Random.Range(80, 90);
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
			change_animation();
		}
		
	}
	
	
	
	public void setinitualdirection (bool direc){
		initialdirection = direc;
	}
	
	
	public void setkind_of_fish (int kind){
		kind_of_fish = kind;
	}
	
	public void change_animation()
	{
			if (direction) {
				//this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish2;
				anim.SetFloat("directx",1f);
			} else {
				//this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish;
				anim.SetFloat("directx",-1f);
			}
		
	}
	
	
	
	
}

