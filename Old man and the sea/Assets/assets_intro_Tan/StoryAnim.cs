using UnityEngine;
using System.Collections;

public class StoryAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void next_scene()
	{
		Application.LoadLevel(2);
	}

}
