using UnityEngine;
using System.Collections;

public class GameCharacter : Character {

	#region UnityGameFunctions
	
		// Use this for initialization
		void Start () {
			health = MAX_HEALTH;
			alive = true;
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		
	#endregion
		
	#region private functions
	
		private void takeDamage(float d){
			health -= (d - defense);
			if(health <= 0){
				toggleAlive(false);
			}
		}
		
		private void playHit() {
			audio.PlayOneShot(hit);
		}
		
		private void toggleAlive(bool a){
			alive = a;
			if(!alive){
				Destroy(this.gameObject);
				audio.PlayOneShot(dead);
			}
		}
		
	#endregion
		
	#region get/set
	
		public float getDamage()  {return damage;}
		public float getHealth()  {return health;}
		public float getSpeed()   {return speed;}
		public float getDefense() {return defense;}
		public float getMana()	  {return mana;}
		public bool  isAlive()    {return alive;}
		
		public void  setAlive(bool a) {toggleAlive(a);}
		
	#endregion
		
	#region Vars
	
		float MAX_HEALTH;
		float TOUCHED_DAMAGE;
		float damage;
		float health;
		float defense;
		float speed;
		float mana;
		bool alive;
		AudioClip hit;
		AudioClip dead;
		
	#endregion
}
