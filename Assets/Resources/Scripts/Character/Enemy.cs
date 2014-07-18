using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	bool move_left = true;
	float move = 0;
	float moveMax = 100;
	float speed = .03f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (move_left) {
			if(move-- < -moveMax){
				move_left = false;
			}
			transform.position += new Vector3(-speed,0f,0f);
		}
		else{
			if(move++ > moveMax) {
				move_left = true;
			}
			transform.position += new Vector3(speed,0f,0f);
		}

	}
}
