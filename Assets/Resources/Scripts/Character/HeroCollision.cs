using UnityEngine;
using System.Collections;

public class HeroCollision : MonoBehaviour {

	JumpController mJumpControl;

	// Use this for initialization
	void Start () {
		print("hero collision");
		mJumpControl = this.GetComponent<JumpController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		string tag = other.tag;
		switch(tag){
		case("platform"):
			if(mJumpControl.isFalling())
				mJumpControl.resetJump();
			break;
		case("enemy"):
			Destroy(this.gameObject);
			break;
		default:
			mJumpControl.setFalling();
			break;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision){
		print ("hero collision exit");
	}
}
