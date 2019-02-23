using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChest : MonoBehaviour {


    [SerializeField]
     public Animator animator;
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
	}
	void Update() {
        print(pressed);
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

		if(!pressed) {
           pressed = true;
           SwitchAnimation ("Open");
           StarterChest.inventoryHeld.AddItem(item1);
           StarterChest.inventoryHeld.AddItem(item2);
		//    inventory.AddItem(item2);
           
		}
	}

    
 	void SwitchAnimation (string layer) {
 		for (int i = 0; i < animator.layerCount; i++) {
 			animator.SetLayerWeight (i, 0);
 		}

 		animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);
 	}
}
