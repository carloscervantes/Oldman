using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	private Vector3 mouseposition;
	public float moveSpeed = 0.04f;
	public float fishTopSpeed = 0.10f; 
	//private fishgravity _fishgravity;
	private float angle;
	private Vector3 object_pos;
	public Transform target;



	// Use this for initialization
	void Start () {
		//_fishgravity = GameObject.Find("Fish").GetComponent<fishgravity>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

			mouseposition = Input.mousePosition;
			mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
			transform.position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
	
		if (Input.GetMouseButton(0)){
			moveSpeed = fishTopSpeed;
		} else moveSpeed = 0.04f;

	
	}
}
