using UnityEngine;
using System.Collections;

public class InitAnimBook : MonoBehaviour {

	private Animator anim;
	public GameObject play;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		anim.SetBool("open", false);
	}
	
	// Update is called once per frame
	void Update () {

		if( Input.GetKeyUp(KeyCode.Return)){
			anim.SetBool("open", true);
			play.gameObject.SetActive(false);
			//Debug.Log("lala");
		}
		if( Input.GetKeyUp(KeyCode.Escape)){
			Application.LoadLevel(4);
		}
	
	}

	public void next_scene()
	{
		Application.LoadLevel(1);
	}




}
