using UnityEngine;
using System.Collections;

public class IceInstantiate : MonoBehaviour {

	GameObject mIceParticle;
	int life, count, magnitude, x, y, xinc, yinc;

	// Use this for initialization
	void Start () {
		mIceParticle = Resources.Load("Prefabs/IceParticle") as GameObject;
		life = 100;
		magnitude = 0;
		count = 0;
		x = 0;
		y = 0;
	}
	
	
	// Update is called once per frame
	void Update () {
		if(life-- <= 0)
			Destroy(this.gameObject);
		//squareEffect();
		roundEffect();
	}
	
	void roundEffect(){
		for(;;){
			if(count-- == 0 ){
				magnitude += 3;
				count = magnitude * 4;
				return;
			}
			spawn();
			Vector3 r = Random.insideUnitCircle;
			r.Normalize();
			r *= magnitude;
			x = (int) r.x;
			y = (int) r.y;
		}
	}
	
	void squareEffect(){
		for(;;){
			if(count-- == 0 ){
				magnitude += 3;
				count = magnitude * 4;
				x = -magnitude;
				y = 0;
				xinc = 3;
				yinc = 3;
				return;
			}
			spawn();
			if(Mathf.Abs(x += xinc) == magnitude){
				xinc *= -1;
			}
			if(Mathf.Abs(y += yinc) == magnitude){
				yinc *= -1;
			}
		}
	}
	
	void spawn(){
		GameObject e = Instantiate(mIceParticle) as GameObject;
		IceParticle spawnedParticle = e.GetComponent<IceParticle>();
		if(spawnedParticle != null) {
			e.transform.position = this.transform.position + new Vector3(x,y,0);
			//spawnedParticle.transform.Rotate(new Vector3(0,0,r));
			//e.transform.position += e.transform.up;
		}
	}
}
