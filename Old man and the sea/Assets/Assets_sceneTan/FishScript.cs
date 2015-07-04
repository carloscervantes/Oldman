using UnityEngine;
using System.Collections;

public class FishScript : MonoBehaviour {
	
	private bool initialdirection;
	private bool direction;

	private float count = 0.0f;
	private float speed = 10.0f;
	private float timingOffset = 1.0f;
	private float height = 0.1f;

	private float lala;

	public GameObject playerfish;
	public float mindis = 4.10f;

	private float dis;

	public Sprite fish;
	public Sprite fish2;
	public Sprite fish3;
	public Sprite fish4;

	private int kind_of_fish;

	
	// Use this for initialization
	void Start () {
		lala = Random.Range(-0.1f, 0.1f);
		height = Random.Range(0.1f, 0.5f);

		direction = initialdirection;
		change_sprite();
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
			change_sprite();
		}

	}
	


	public void setinitualdirection (bool direc){
		initialdirection = direc;
	}


	public void setkind_of_fish (int kind){
		kind_of_fish = kind;
	}

	public void change_sprite()
	{
		switch (kind_of_fish) 
		{
			case 0:
			if (direction) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish2;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish;
			}
			break;
			case 1:
			if (direction) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish3;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish4;
			}
			break;
			case 2:
			if (direction) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish2;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish;
			}
			break;
			case 3:
			if (direction) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish2;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish;
			}
			break;
			case 4:
			if (direction) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish2;
			} else {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = fish;
			}
			break;
		}

	}




}
