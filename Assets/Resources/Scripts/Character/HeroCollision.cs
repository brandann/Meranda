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
			if(mJumpControl.isFalling()){
				mJumpControl.resetJump();
				float platY = other.transform.localPosition.y;// + other.gameObject.GetComponent<SpriteRenderer>().bounds.max.y/2;
				this.transform.position = new Vector3(this.transform.position.x, platY, this.transform.position.z);
			}
			break;
		case("enemy"):
			Destroy(this.gameObject);
			break;
		case("wall"):
			HeroCharacter h = this.gameObject.GetComponent<HeroCharacter>();
			float velocity = h.lastMovment;
			this.transform.position += new Vector3(-.2f, 0, 0);
			break;
		default:
			break;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision){
		print ("hero collision exit");
	}
}
