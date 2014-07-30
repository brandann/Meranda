using UnityEngine;
using System.Collections;

public class JumpController : MonoBehaviour {

	private enum ActionState {ambient, jumping, falling, walking};
	private ActionState currentActionState = ActionState.ambient;
	const int MIN_JUMP_HEIGHT = 2;
	const int MAX_JUMP_HEIGHT = 50;
	int mJumpHeight = MIN_JUMP_HEIGHT;
	int mJumpTravel = 0;
	const float ROTATE_SPEED = 30;
	const float SPEED = .2f;
	const float SPEED_MULT = 50f;
	SpriteController mSpriteController;
	
	// Use this for initialization
	void Start () {
		mSpriteController = this.GetComponent<SpriteController>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetAxis ("Jump") > 0f) {
			if(currentActionState == ActionState.ambient){
				currentActionState = ActionState.jumping;
			}
			else if(currentActionState == ActionState.jumping) {
				if(mJumpHeight != MAX_JUMP_HEIGHT) {
					mJumpHeight++;
				}
			}
		}
		
		switch(currentActionState){
		case(ActionState.ambient):
			transform.rotation = Quaternion.identity;
			break;
		case(ActionState.jumping):
			if(mJumpHeight != mJumpTravel++){
				moveBy(0,SPEED,0);
			}
			if(mJumpHeight == mJumpTravel) {
				currentActionState = ActionState.falling;
			}
			break;
		case(ActionState.falling):
			if(mJumpTravel-- > 0){
				moveBy(0,-SPEED,0);
			}
			if(mJumpTravel == 0) {
				currentActionState = ActionState.ambient;
				resetJump();
			}
			break;
		}
		
	}
	
	private void moveBy(float x, float y, float z){
		this.transform.position += new Vector3(x,y,z);
		if(mSpriteController.isRight() || mSpriteController.isLastRight())
			this.transform.RotateAround(this.transform.position,new Vector3(0, 0, 1), -ROTATE_SPEED);
		else
			this.transform.RotateAround(this.transform.position,new Vector3(0, 0, 1), ROTATE_SPEED);
	}
	
	private void resetJump(){
		mJumpTravel = 0;
		mJumpHeight = MIN_JUMP_HEIGHT;
	}
	
	public bool isJumping(){return currentActionState == ActionState.jumping;}
	public bool isFalling(){return currentActionState == ActionState.falling;}
}
