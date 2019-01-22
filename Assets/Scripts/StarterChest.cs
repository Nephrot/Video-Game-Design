using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterChest : MonoBehaviour {


    [SerializeField]
     public Animator animator;
	 [SerializeField]
	 public GameObject objectChest;
	 bool pressed = false;
	 [SerializeField] Inventory inventory;
	 [SerializeField] Item item1;
	 [SerializeField] Item item2;
	 [SerializeField] Item item3;
	 [SerializeField] GameObject weapon;
	 [SerializeField] GameObject potion;
	 [SerializeField] GameObject tunic;

	// Use this for initialization
	void Start() {
		 weapon.SetActive(false);
		   potion.SetActive(false);
		   tunic.SetActive(false);
	}
	void Update() {
	}
	void OnMouseOver () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
		 if(!pressed) {
 			SwitchAnimation ("Selected");
		 }
 		
 	}
 	void OnMouseExit () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
 		if(!pressed) {
 			SwitchAnimation ("Idle");
		 }
 	}
	
	void OnMouseDown() {
		
		if (CutsceneTutorial.timer > 30.4f && !pressed) {
           SwitchAnimation ("Open");
		   inventory.AddItem(item1);
		   inventory.AddItem(item2);
		   inventory.AddItem(item3);
		   weapon.SetActive(true);
		   potion.SetActive(true);
		   tunic.SetActive(true);
		   pressed = true;
		   CutsceneTutorial.stopTimer = false;
		   CutsceneTutorial.timer = 30.9f;
		   CutsceneTutorial.option3 = 2;
		}
	}

    
 	void SwitchAnimation (string layer) {
 		for (int i = 0; i < animator.layerCount; i++) {
 			animator.SetLayerWeight (i, 0);
 		}

 		animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);
 	}
}
