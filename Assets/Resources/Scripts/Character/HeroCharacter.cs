using UnityEngine;
using System.Collections;

public class HeroCharacter : GameCharacter {

	string name;
	
	SpriteController mSpriteController;
	GameObject mIceInsantiate;
	mainCamera camera;
	public float lastMovment;
	
	// Use this for initialization
	void Start () {
		mSpriteController = this.GetComponent<SpriteController>();
		camera = GameObject.Find ("Main Camera").GetComponent<mainCamera>();
		mIceInsantiate = Resources.Load("Prefabs/IceInstantiate") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
		float movement = Input.GetAxis ("Horizontal");
		if(movement > float.MinValue){
			lastMovment = movement * SPEED;
			moveBy(lastMovment ,0 ,0);
			moveCamera();
			mSpriteController.setDirection(movement);
		}
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			spawnIce ();
		}
	}
	
	
	
	void spawnIce(){
		GameObject e = Instantiate(mIceInsantiate) as GameObject;
		IceInstantiate spawnedParticle = e.GetComponent<IceInstantiate>();
		if(spawnedParticle != null) {
			e.transform.position = this.transform.position;
		}
	}
	
	public string getName() {return name;}
	private void moveBy(float x, float y, float z) { this.transform.position += new Vector3(x,y,z); }
	private void moveCamera(){
		if(camera != null)
			camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, -20);
	}
}
