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
	public static float mindis = 2.10f;
	
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

		dis = Vector3.Distance(this.transform.position, playerfish.gameObject.transform.position);

		//si es un pez atun o un anzuelo
		if (kind_of_fish == 0 || kind_of_fish == 1) {
			count += Time.deltaTime / Random.Range (90, 100);
			var offset = this.transform.position.y + Mathf.Sin ((Time.time + lala) * speed + timingOffset) * height / 2;
			//transform.position = new Vector3(this.transform.position.x + count, offset, 0);
			if (direction) {
				transform.position = new Vector3 (this.transform.position.x + count, offset, 0);
			} else {
				transform.position = new Vector3 (this.transform.position.x - count, offset, 0);
			}

			//Cambio de direccion segun la distancia
			//Debug.Log(dis);
			if (dis <= mindis)
			{
				direction = !initialdirection;
				change_animation();
			}

		}
		// si es un tiburon
		if (kind_of_fish == 2 ) {
			count += Time.deltaTime / Random.Range (150, 160);
			var offset = this.transform.position.y + Mathf.Sin ((Time.time + lala) * 10.0f + timingOffset) * 0.01f / 2;
			//transform.position = new Vector3(this.transform.position.x + count, offset, 0);
			if (direction) {
				transform.position = new Vector3 (this.transform.position.x + count, offset, 0);
			} else {
				transform.position = new Vector3 (this.transform.position.x - count, offset, 0);
			}


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

