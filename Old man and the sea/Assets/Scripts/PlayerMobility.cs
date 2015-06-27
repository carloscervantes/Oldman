using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	//public float inputX = Input.GetAxis("Horizontal");
	//public float inputY = Input.GetAxis("Vertical");
	
	void Start()
	{
		
	}
	
	void FixedUpdate()
	{
			
		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f),
		                                                   Mathf.Lerp(0,  Input.GetAxis("Vertical") * speed, 0.8f));
	

	}
}
