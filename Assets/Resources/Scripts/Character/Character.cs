using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	protected Vector3 startPostion;
	protected const float SPEED = .2f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Vector3 getStartPosition() { return startPostion; }
	public float getSpeed() { return SPEED; }
	
}
