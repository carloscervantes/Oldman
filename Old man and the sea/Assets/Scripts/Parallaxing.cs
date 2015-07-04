using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] BGelements;	//array of all backgrounds and foregrounds to be parallexed
	private float[] Parallax;		//proportion of the camera movement to BG elements. 
	public float smoothing = 1f; 	//how smooth the parallex is going to be. SET THIS ABOVE 0!

	private Transform cam; 			//reference to Main Camera transform.
	private Vector3 previousCamPos;	//stores positin of camera in the previous frame.
 
	//is called before Start(). Great for references.
	void Awake () {
		//set up the camera reference.
		//cam = Camera.main.transform;
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		// The previous frame had the current frame's camera position
		previousCamPos = cam.position;


		//assigning corresponding Parallax.
		Parallax  = new float[BGelements.Length];
		for (int i = 0; i <	BGelements.Length; i++) {
			Parallax[i] = BGelements[i].position.z*-1;		
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	//for each BG
		for (int i = 0; i < BGelements.Length; i++) {
			//Parallax is the opposite of the camera movement because the previous frame multiplied by scale.
			float parallaxx = (previousCamPos.x -cam.position.x) * Parallax[i];
			//float parallaxy = (previousCamPos.y -cam.position.y) * Parallax[i];

			// set a target  x position which is the current position plus  the parallax 
			float backgroundTargetPosX = BGelements[i].position.x + parallaxx;
			//float backgroundTargetPosY = BGelements[i].position.y + parallaxy;

			//Create  a target position which is the backgrounds current position with its target x position
			Vector3 backgroundTargetPos =  new Vector3 (backgroundTargetPosX, BGelements[i].position.y, BGelements[i].position.z);

			//Lerp between current position and the target position
			BGelements[i].position = Vector3.Lerp (BGelements[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		//set the previousCamPos to the cameras position at the end of the frame

		previousCamPos = cam.position; 
	}
}
