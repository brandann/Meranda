using UnityEngine;
using System.Collections;

public class RecursiveInstantiate : MonoBehaviour {

	GameObject mRecursiveParticle;

	// Use this for initialization
	void Start () {
		mIceParticle = Resources.Load("Prefabs/mRecursiveParticle") as GameObject;
		spawn (0);
		spawn (90);
		spawn (180);
		spawn (270);
		Destroy(this);
	}
	
	void spawn(float r){
		GameObject e = Instantiate(mRecursiveParticle) as GameObject;
		mRecursiveParticle spawnedParticle = e.GetComponent<mRecursiveParticle>();
		if(spawnedParticle != null) {
			e.transform.position = this.transform.position;
			spawnedParticle.transform.Rotate(new Vector3(0,0,r));
			e.transform.position += e.transform.up;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
