using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterChest : MonoBehaviour {


    [SerializeField]
     public Animator animator;
	 [SerializeField]
	 public GameObject objectChest;
	// Use this for initialization
	void Start() {
		objectChest.SetActive(false);
	}
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			objectChest.SetActive(false);
		}
	}
	void OnMouseOver () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
 			SwitchAnimation ("Selected");
 		
 	}
 	void OnMouseExit () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
 			SwitchAnimation ("Idle");
 	}
	
	void OnMouseDown() {
		
		if (CutsceneTutorial.timer > 28f ) {
           objectChest.SetActive(true);
		}
	}

    
 	void SwitchAnimation (string layer) {
 		for (int i = 0; i < animator.layerCount; i++) {
 			animator.SetLayerWeight (i, 0);
 		}

 		animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);
 	}
}
