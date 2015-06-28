using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour {

	public bool hasbounds;
	
	public Vector3 minPlayerPos;
	public Vector3 maxPlayerPos;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (hasbounds){
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPlayerPos.x, maxPlayerPos.x), 
			                                 Mathf.Clamp(transform.position.y, minPlayerPos.y, maxPlayerPos.y),
			                                 Mathf.Clamp(transform.position.z, minPlayerPos.z, maxPlayerPos.z));
		}
		
	}
}
