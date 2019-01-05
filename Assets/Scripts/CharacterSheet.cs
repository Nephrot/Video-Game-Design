using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour {
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
int ButtonCount = 0;
	// Update is called once per frame
   void Update(){
       Move();
      
   }
   void Move() {
    movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
    mouseMovement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && (movement.x != 0 || movement.y != 0)) {
      SwitchAnimation("Attack Walk Layer");
      if((mouseMovement.x >= sensitivity || mouseMovement.x <= -(sensitivity)) || (mouseMovement.y >= sensitivity || mouseMovement.y <= -(sensitivity))) {
      animator.SetFloat("HorizontalMouse", mouseMovement.x);
      animator.SetFloat("VerticalMouse", mouseMovement.y);
      }
    }
    else if(Input.GetMouseButton(0)) {
      SwitchAnimation("Attack Idle Layer");
       if((mouseMovement.x >= sensitivity || mouseMovement.x <= -(sensitivity)) || (mouseMovement.y >= sensitivity || mouseMovement.y <= -(sensitivity))) {
      animator.SetFloat("HorizontalMouse", mouseMovement.x);
      animator.SetFloat("VerticalMouse", mouseMovement.y);
      }
    }
    else if(movement.x != 0 || movement.y != 0) {  
      SwitchAnimation("Walk Layer");
      animator.SetFloat("Horizontal", movement.x);
      animator.SetFloat("Vertical", movement.y);
      
    } 
    else {
      SwitchAnimation("Idle Layer");
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
