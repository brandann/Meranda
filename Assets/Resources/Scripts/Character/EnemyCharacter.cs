﻿using UnityEngine;
using System.Collections;

public class EnemyCharacter : GameCharacter {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		print ("Enemy Partilce collider");
		string tag = other.tag;
		switch(tag){
		case("platform"):
			break;
		case("ice"):
			break;
		default:
			break;
		}
	}
}
