using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
public Rigidbody2D rb;

public Animator animator;
Vector3 movement;
public float moveSpeed = 3f;	
	// Update is called once per frame
   void Update(){
    Move();
   }
   void Move(){
    movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);    
    animator.SetFloat("Horizontal", movement.x);
    animator.SetFloat("Vertical", movement.y);
    animator.SetFloat("Magnitude", movement.magnitude);
   }
}
