using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public Animator anim;
	private PlayerMobility _playermobility;

	void Start () {
		anim = GetComponent<Animator>();
		_playermobility = GetComponent<PlayerMobility>();
	}

	/*void Update () {
		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");

		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
			anim.SetBool ("swimming", true);
			if (InputX > 0 ) {
				anim.SetFloat("speedX", 1f);
			}
			else if (InputX < 0) {
				anim.SetFloat("speedX", -1f);
			}
			else {
				anim.SetFloat("speedX", 0);
			}
			if (InputY > 0 ) {
				anim.SetFloat("speedY", 1f);
			}
			else if (InputY < 0) {
				anim.SetFloat("speedY", -1f);
			}
			else {
				anim.SetFloat("speedY", 0);
			}
			//not moving, set the anim
		} else {
			anim.SetBool ("swimming", false);
		}

		anim.SetFloat("speedX", Input.GetAxis("Horizontal"));
		anim.SetFloat("speedY", Input.GetAxis("Vertical"));

	}*/

	void Update () {
		float InputX = Input.GetAxisRaw ("Horizontal");
		float InputY = Input.GetAxisRaw ("Vertical");
		
		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			anim.SetBool ("swimming", true);
			setPlayerDirectionAnim(InputX, InputY);
		} else {
			anim.SetBool ("swimming", false);
		}
	}
	
	void setPlayerDirectionAnim(float horizInput, float vertInput) {
		anim.SetFloat ("speedX", horizInput);
		anim.SetFloat ("speedY", vertInput);
		anim.SetFloat ("LastMoveX", horizInput);
		anim.SetFloat ("LastMoveY", vertInput);
	}

	void FixedUpdate() {
		
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");
		
		if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){
			
			if (lastInputX > 0) {
				anim.SetFloat("LastMoveX", 1f);
			}
			else if (lastInputX < 0) {
				anim.SetFloat("LastMoveX", -1f);
			}
			else {
				anim.SetFloat("LastMoveX", 0);
			}
			
			if (lastInputY > 0) {
				anim.SetFloat("LastMoveY", 1f);
			}
			else if (lastInputY < 0) {
				anim.SetFloat("LastMoveY", -1f);
			}
			else {
				anim.SetFloat("LastMoveY", 0);
			}
		}
	}
}