using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	public bool hooked;
	private bool canpress;
	private bool fishcaught;
	private bool fishescapes;
	private float goodcounter = 0;
	private float badcounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hooked && canpress) {
			if (Input.GetButton("Fire1")){
				goodcounter += 1f;
			} else if ((hooked) && (canpress = false)){
				badcounter += 1f;
				goodcounter -=1f;
			}
		}

		if (badcounter == 10){
			fishcaught = true;
		}

		if (goodcounter == 10){
			fishcaught = true;
		}
	
	}
}
