using UnityEngine;
using System.Collections;

public class HeroCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print("hero collision");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		string tag = other.tag;
		switch(tag){
			case("enemy"):
				Destroy(this.gameObject);
				break;
			case("platform"):
				break;
		}
	}
	
	void OnTriggerExit2D(Collider2D collision){
		print ("hero collision exit");
	}
}
