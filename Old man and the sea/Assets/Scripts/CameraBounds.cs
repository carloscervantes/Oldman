using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {
	public bool hasbounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (hasbounds){
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x), 
			                                 Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
			                                 Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	
	}
}
