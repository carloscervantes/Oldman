using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	private Vector3 mouseposition;
	public float moveSpeed = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)) {
			mouseposition = Input.mousePosition;
			mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);
			transform.position = Vector2.Lerp(transform.position, mouseposition, moveSpeed);
		}
	
	}
}
