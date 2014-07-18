using UnityEngine;
using System.Collections;

public class OpeningStory : MonoBehaviour {
	enum state {
		one, two, three, four, five, six, seven, pause
	};
	private AudioClip backgroundAudio; //not used
	
	string one = "Kaylee And River\nAre Sisters";
	string two = "But a Wizard\nTurned Them Into Snails";
	string three = "Kaylee And River\nWant To Be Girls Again";
	string four = "However They Are Trapped In Meranda"; //(Another Magical Dimension)
	string five = ""; //And They Are Snails
	string six = "The Sisters Must Find the Wizard\nTo Return To Their Original Forms...";
	string seven = "";
	string pause = "";

	state currentState = state.one;
	state lastState;
	int count = 0;
	int interval;
	const int INTERVAL_MULT = 0;
	
	mainCamera camera;

	// Use this for initialization
	void Start () {
		this.guiText.text = one;
		interval = one.Length * INTERVAL_MULT;
		camera = GameObject.Find ("Main Camera").GetComponent<mainCamera>();
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (count > interval) {
			count = 0;
			if(currentState != state.pause){
				lastState = currentState;
				currentState = state.pause;
			}
			else { //currentState == state.pause
				switch(lastState){
				case state.one:
					currentState = state.two;
					this.guiText.text = two;
					interval = two.Length * INTERVAL_MULT;
					break;
				case state.two:
					currentState = state.three;
					this.guiText.text = three;
					interval = three.Length * INTERVAL_MULT;
					break;
				case state.three:
					currentState = state.four;
					this.guiText.text = four;
					interval = four.Length * INTERVAL_MULT;
					break;
				case state.four:
					currentState = state.five;
					this.guiText.text = five;
					interval = five.Length * INTERVAL_MULT;
					break;
				case state.five:
					currentState = state.six;
					this.guiText.text = six;
					interval = six.Length * INTERVAL_MULT;
					break;
				case state.six:
					currentState = state.seven;
					this.guiText.text = seven;
					camera.transform.position = new Vector3(0,0,-20);
					//camera.camera.backgroundColor = new Color(70,147,236,0);
					//camera.audio.PlayOneShot(backgroundAudio);
					camera.audio.Play();
					break;
				}
			}
		}
	}
}
