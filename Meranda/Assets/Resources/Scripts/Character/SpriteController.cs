using UnityEngine;
using System.Collections;


public class SpriteController : MonoBehaviour {

	private enum DirectionState {ambient, up, left, down, right, jump, fall};
	private DirectionState currentDirectionState = DirectionState.ambient;
	private DirectionState lastDirection = DirectionState.right;
	
	JumpController mJumpController;
	SpriteRenderer mSpriteRenderer;
	
	#region sprites
	// SPRITES ARE LOADED IN THE PREFAB
	public Sprite up;
	public Sprite left;
	public Sprite down;
	public Sprite right;
	public Sprite jump;
	public Sprite fall;
	private bool mUpdateSprite = false;
	#endregion
	
	#region setDirectionState
	public bool setDirection(float movement){
		if(movement == 0){
			setAmbient();
			mUpdateSprite = true;
		}
		else if(movement > 0){
			setRight();
			mUpdateSprite = true;
		}
		else if(movement < 0){
			setLeft();
			mUpdateSprite = true;
		}
		return mUpdateSprite;
	}
	
	public bool setJumping(){
		if(mJumpController.isJumping()){
			currentDirectionState = DirectionState.jump;
			mUpdateSprite = true;
		}
		else if(mJumpController.isFalling()){
			currentDirectionState = DirectionState.fall;
			mUpdateSprite = true;
		}
		return mUpdateSprite;
	}
	
	public bool setUp(){
		if(currentDirectionState != DirectionState.up){
			currentDirectionState = DirectionState.up;
			return true;
		}
		return false;
	}
	
	public bool setLeft(){
		if(currentDirectionState != DirectionState.left){
			currentDirectionState = DirectionState.left;
			lastDirection = DirectionState.left;
			return true;
		}
		return false;
	}
	
	public bool setDown(){
		if(currentDirectionState != DirectionState.down){
			currentDirectionState = DirectionState.down;
			return true;
		}
		return false;
	}
	
	public bool setRight(){
		if(currentDirectionState != DirectionState.right){
			currentDirectionState = DirectionState.right;
			lastDirection = DirectionState.right;
			return true;
		}
		return false;
	}
	
	public bool setAmbient(){
		if(currentDirectionState != DirectionState.ambient){
			currentDirectionState = DirectionState.ambient;
			return true;
		}
		return false;
	}
	
	public bool setJump(){
		if(currentDirectionState != DirectionState.jump){
			currentDirectionState = DirectionState.jump;
			return true;
		}
		return false;
	}
	
	public bool setFall(){
		if(currentDirectionState != DirectionState.fall){
			currentDirectionState = DirectionState.fall;
			return true;
		}
		return false;
	}
	#endregion

	#region is
	public bool isRight() {return currentDirectionState == DirectionState.right;}
	public bool isLastRight() {return lastDirection == DirectionState.right;}
	#endregion
	
	
	// Use this for initialization
	void Start () {
		mJumpController = this.GetComponent<JumpController>();
		mSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		setJumping();
		if(mUpdateSprite)
			updateSprite();
	}
	
	public void updateSprite(){
		//DirectionState {ambient, up, left, down, right, jump, fall};
		switch(currentDirectionState){
		case(DirectionState.ambient):
			if(lastDirection == DirectionState.right)
				mSpriteRenderer.sprite = right;
			else if(lastDirection == DirectionState.left)
				mSpriteRenderer.sprite = left;
			break;
		case(DirectionState.up): break;
		case(DirectionState.left): 
			mSpriteRenderer.sprite = left;
			break;
		case(DirectionState.down): break;
		case(DirectionState.right): 
			mSpriteRenderer.sprite = right;
			break;
		case(DirectionState.jump): 
			mSpriteRenderer.sprite = jump;
			break;
		case(DirectionState.fall): 
			mSpriteRenderer.sprite = fall;
			break;
		}
	}
}
