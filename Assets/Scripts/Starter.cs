using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {
public Rigidbody2D rb;

public Animator animator;
Vector3 movement;
Vector3 mouseMovement;

[SerializeField]
private Stats stamina;
public static float moveSpeed = 3f;	
[SerializeField]
public float sensitivity = 0.5f;
float ButtonLasts = 0.5f; // Half a second before reset
private bool isOpen;
int ButtonCount = 0;
	// Update is called once per frame
   void Update(){
       Move();
       GetInput();
   }
   void Move() {
    movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
    if(movement.x != 0 || movement.y != 0) {  
      SwitchAnimation("Walk Layer");
      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      
    } 
    else {
      SwitchAnimation("Idle Layer");
    }  
   }

   void GetInput() {
     if (Input.GetKeyDown (KeyCode.T)) {
			print("T");
			print(isOpen);
			if(!isOpen) {
				InventoryManager.INSTANCE.openContainer(new PlayerContainer(null, null));
				isOpen = true;
			}
			else {
				InventoryManager.INSTANCE.closeContainer();
				isOpen = false;
			}
		}
   }

   void SwitchAnimation(string layer) {
     for (int i = 0; i < animator.layerCount; i++)
     {
         animator.SetLayerWeight(i, 0);
     }

     animator.SetLayerWeight(animator.GetLayerIndex(layer), 1);
   }
}

