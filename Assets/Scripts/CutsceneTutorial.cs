using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;  

public class CutsceneTutorial : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	GameObject game;
	
	[SerializeField]
	GameObject explosion;
	[SerializeField]
	Rigidbody2D rb;
	[SerializeField]
	Animator animator;
	[SerializeField]
	public static float timer = 0;
	float wait;
	public static bool stopTimer = false;
	[SerializeField]
	GameObject image;
	[SerializeField]
	Text chat;
	[SerializeField]
	Text chat1;
	
	[SerializeField]
	Text chat2;
	[SerializeField]
	Text chat3;
	[SerializeField]
	Text chat4;
	[SerializeField]
	GameObject image2;
	[SerializeField]
	GameObject image3;
	[SerializeField]
	GameObject player;
	[SerializeField]
	GameObject unknown;
	public static int option = 0;
	public static bool resume = false;
	public static float tipsTimer = 0;
	float tipsWait;
	float distance;
	[SerializeField]
	BoxCollider2D colliderWall;
	[SerializeField]
	Rigidbody2D colliderRb;
	float tipsTimer2;
	public Text header;
	public Text tooltip;
	int option2 = 1;
	bool summon;
	void Start () {
      image3.SetActive(false);
	  explosion.SetActive(false);
	}
	
	
	// Update is called once per frame
	void Update () {
		if(!stopTimer) {
		timer += Time.deltaTime;
		}
		tipsTimer += Time.deltaTime;
		if(option2 == 2) {
		tipsTimer2 += Time.deltaTime;
		}
		if(timer < 1.5f) {
		  	rb.velocity = new Vector2(0, 3);
			  SwitchAnimation("Forward");
		}
		else if(timer < 1.7f) {
			rb.velocity = new Vector2(-1, 0);
			SwitchAnimation("Left");
		}
		else if(timer > 1.7f && timer < 1.8f) {
           rb.velocity = new Vector2(0, 0);
			SwitchAnimation("Idle");
		}
		else if( timer < 9.3f && timer > 1.8f) {

		}
		else if(timer > 9.3f && timer < 10f) {
			stopTimer = true;
		}
		else if(timer > 10f && timer < 14f) {
		}
		else if(timer > 14f && timer < 15f) {
            image2.SetActive(false);
			chat1.text = "-) Who are you?";
			chat2.text = "-) Get me out of here now!";
			chat3.text = "-) I don't have to listen to the likes of you.";
			chat4.text = "-) How can I repay you.";
			image3.SetActive(true);
			stopTimer = true;
		}
		else if(timer > 20f && timer < 20.4f) {
			chat.text = "Unknown: It is probably best to get away from the door now or this is going to hurt.";
			distance = (player.transform.position.x - unknown.transform.position.x);
            option2 = 2;
            if(distance < -5) {
				image2.SetActive(false);
			}
			SwitchAnimation("Right");
			rb.velocity = new Vector2(3, 0);
		}
		else if(timer > 20.4f && timer < 23.5 ) {
            SwitchAnimation("Idle");
			rb.velocity = new Vector2(0, 0);
			stopTimer = true;
		}
		else if(timer > 23.5 && timer < 23.9) {
			image2.SetActive(false);
			explosion.SetActive(true);	
		}
		else if(timer > 23.8 && timer < 24) {
			explosion.SetActive(false);
			stopTimer = true;
			distance = (player.transform.position.x - unknown.transform.position.x);
		}
		else if(timer > 25 && timer < 28) {
            chat.text = "Unknown: I've smuggled some equipment beforehand in the chest, I hear you are an excellent " + Check.classOf + ".";
            image2.SetActive(true);
		}
		else if(timer > 28 && timer < 30) {
			chat.text = "Unknown: I'll be back I need to handle the other guards, deal with the ones here they've been corrupted by Jormungandr.";
		}
		else if(timer > 30 && timer < 30.4) {
			SwitchAnimation("Smoke Bomb");
		}
		else if(timer > 30.4 && timer < 32) {
			unknown.SetActive(false);
		    image2.SetActive(false);
		}
		if(timer > 23.8 && timer < 24 && distance > -1) {
			timer = 25f;
			stopTimer = false;
		}
        if(timer > 20.4f && timer < 23.5 && stopTimer == true ) {
			distance = (player.transform.position.x - unknown.transform.position.x);
			summon = true;
			
            if(distance < -5) {
				timer = 23.6f;
				stopTimer = false;
				Destroy (colliderWall);
				Destroy (colliderRb);
			}
		}
		if(option == 1) {
			image3.SetActive(false);
			chat.text = "Unknown: Not yet... Not here son. Just come with me.";
            image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;
		}
		else if(option == 2 || option == 3) {
			image3.SetActive(false);
			chat.text = "Unknown: Prison's changed you, hmm, I can deal with it I guess just don't test me.";
            image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;
		}
		else if(option == 4) {
			image3.SetActive(false);
			chat.text = "Unknown: You just have to come with me son, no strings attached.";
			image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;
		}
	    if(tipsTimer < 4f && tipsTimer > 1.7f) {	
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		if(tipsTimer > 7f && tipsTimer < 9.3f) {	
			image.transform.position = new Vector3(image.transform.position.x+5, image.transform.position.y, image.transform.position.z);
		}
		if(tipsTimer2 > 0f && tipsTimer2 < 2.3f ) {	
			header.text = "Move";
			tooltip.text = "To move use the WASD keys correspondingly, make sure to move far away from him to continue.";
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		else if(tipsTimer2 > 4f && !summon) {
		   option2 = 1;
		}
		else if(tipsTimer2 > 4f && tipsTimer2 < 6.3f ) {	
			option2 = 2;
			image.transform.position = new Vector3(image.transform.position.x+5, image.transform.position.y, image.transform.position.z);
		}
	}
	void SwitchAnimation(string layer) {
     for (int i = 0; i < animator.layerCount; i++)
     {
         animator.SetLayerWeight(i, 0);
     }

     animator.SetLayerWeight(animator.GetLayerIndex(layer), 1);
   }
    public void choose1 () {
	    option = 1;
		resume = true;
	}
	public void choose2 () {
	    option = 2;
		resume = true;
	}
	public void choose3 () {
	    option = 3;
		resume = true;
	}
	public void choose4 () {
	    option = 4;
		resume = true;
	}
}
