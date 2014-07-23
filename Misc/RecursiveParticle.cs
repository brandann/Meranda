using UnityEngine;
using System.Collections;

public class RecursiveParticle : MonoBehaviour {

	public Sprite ice01, ice02, ice03, ice04, ice05;
	GameObject mRecursiveParticle;
	int life;
	
	// Use this for initialization
	void Start () {
		mIceParticle = Resources.Load("Prefabs/mRecursiveParticle") as GameObject;
		randomSprite();
		life = Random.Range(50,500);
		spawn ();
	}
	
	// Update is called once per frame
	void Update () {
		if(life-- <= 0)
			Destroy(this.gameObject);
	}
	
	void spawn(){
		float r = Random.Range(0,4) * 90;
		GameObject e = Instantiate(mRecursiveParticle) as GameObject;
		mRecursiveParticle spawnedParticle = e.GetComponent<mRecursiveParticle>();
		if(spawnedParticle != null) {
			e.transform.position = this.transform.position;
			spawnedParticle.transform.Rotate(new Vector3(0,0,r));
			e.transform.position += e.transform.up;
		}
	}
	
	private void randomSprite(){
		SpriteRenderer mSpriteRenderer = GetComponent<SpriteRenderer>();
		switch(Random.Range(0,5)) {
			case (0):
				mSpriteRenderer.sprite = ice01;
				break;
			case 1:
				mSpriteRenderer.sprite = ice02;
				break;
			case 2:
				mSpriteRenderer.sprite = ice03;
				break;
			case 3:
				mSpriteRenderer.sprite = ice04;
				break;
			case 4:
				mSpriteRenderer.sprite = ice05;
				break;
		}
	}
}
