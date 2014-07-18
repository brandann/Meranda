using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
	
	const float SPEED = .2f;
	const float SPEED_MULT = 50f;
	
	SpriteController mSpriteController;
	mainCamera camera;
	
	// Use this for initialization
	void Start () {
		mSpriteController = this.GetComponent<SpriteController>();
		camera = GameObject.Find ("Main Camera").GetComponent<mainCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		
		float movement = Input.GetAxis ("Horizontal");
		moveBy(movement*SPEED,0,0);
		mSpriteController.setDirection(movement);
	}
	
	private void moveBy(float x, float y, float z){
		this.transform.position += new Vector3(x,y,z);
		float heroX = transform.position.x;
		float cameraY = camera.transform.position.y;
		float cameraZ = -20;
		camera.transform.position = new Vector3(heroX, cameraY,cameraZ);
	}
}
