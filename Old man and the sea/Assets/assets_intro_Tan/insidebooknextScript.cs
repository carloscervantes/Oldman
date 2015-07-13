using UnityEngine;
using System.Collections;

public class insidebooknextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyUp(KeyCode.Escape)){
			Application.LoadLevel(4);
		}
	
	}

	public void next_scene()
	{
		Application.LoadLevel(3);
	}
}
