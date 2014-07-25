using UnityEngine;
using System.Collections;

public class IceParticle : MonoBehaviour {

	public Sprite ice01, ice02, ice03, ice04, ice05;
	int life;
	public int lifeMin;
	public int lifeMax;
	float scale = .1f;
	bool rand = true;
	
	// Use this for initialization
	void Start () {
		randomSprite();
		life = Random.Range(lifeMin, lifeMax);
		if(rand){
			this.transform.localScale = new Vector3(.1f,.1f,1f);
			this.transform.Rotate(new Vector3(0,0,Random.Range(0,360)));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(life-- <= 0)
			Destroy(this.gameObject);
		if(rand){
			this.transform.localScale += new Vector3(scale,scale,0f);
			randomDirection();
		}
	}
	
	private void randomDirection(){
		this.transform.position += this.transform.up * .2f;
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
