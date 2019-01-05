 using System.Collections;
 using UnityEngine.EventSystems;
 using UnityEngine.UI;
 using UnityEngine;

 public class UnknownSelected : MonoBehaviour {

 	public GameObject image;
 	[SerializeField]
 	Animator animator;
 	float timer = 0;
 	float wait;
 	bool clicked = false;
	[SerializeField]
	Text chat;
	[SerializeField]
	GameObject chatbox;
	bool pressed = false;
	void Start() {
		chatbox.SetActive(false);
	}
 	void Update () {
 		timer += Time.deltaTime;
		 
 	}
 	void OnMouseOver () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
 		if (timer > 1.8f) {
 			SwitchAnimation ("Selected");
 		}
 	}
 	void OnMouseExit () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
 		if (timer > 1.8f) {
 			SwitchAnimation ("Idle");
 		}
 	}
	
	void OnMouseDown() {
		
		if (timer > 1.8f && !pressed) {
         chat.text = "Unknown: So you are him huh... " + Check.nameCharacter + ". we have no time to waste. I got to get you out of this cell.";
		 chatbox.SetActive(true);
		 CutsceneTutorial.timer = 10f;
		 CutsceneTutorial.stopTimer = false;
		 pressed = true;
		 }
	}

    
 	void SwitchAnimation (string layer) {
 		for (int i = 0; i < animator.layerCount; i++) {
 			animator.SetLayerWeight (i, 0);
 		}

 		animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);
 	}
 }