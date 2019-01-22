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
	Animation frozen1;
	[SerializeField]
	Animator frozen;
	
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
	public Collider2D colliders;
	float tipsWait;
	float distance;
	[SerializeField]
	BoxCollider2D colliderWall;
	[SerializeField]
	Rigidbody2D colliderRb;
	float tipsTimer2;
	float tipsTimer3;
	public Text header;
	public Text tooltip;
	int option2 = 1;
	public static int option3 = 1;
	public Collider2D resumeTut;
	bool dummy = false;
	bool summon;
	 [SerializeField] GameObject weapon;
	 [SerializeField] GameObject potion;
	 [SerializeField] GameObject tunic;
	 [SerializeField] GameObject person;
	 [SerializeField] GameObject Lich;
	 [SerializeField] GameObject Person;
	 public GameObject blockingCollider1;
	  public GameObject blockingCollider2;
	void Start () {
      image3.SetActive(false);
	  explosion.SetActive(false);
	  Lich.SetActive(false);
	  frozen.enabled = false;
	  blockingCollider2.SetActive(false);
	}
	
	
	// Update is called once per frame
	void Update () {
		// print(timer);
		// print(stopTimer);
		if(!stopTimer) {
		timer += Time.deltaTime;
		}
		tipsTimer += Time.deltaTime;
		if(option2 == 2) {
		tipsTimer2 += Time.deltaTime;
		}
		if(option3 == 2) {
		tipsTimer3 += Time.deltaTime;
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
			chat2.text = "-) I've got a competition to get to!";
			chat3.text = "-) I don't have to listen to you!";
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
			chat.text = "Unknown: I'll be back I need to go protect the other competitions, deal with the Lich's here they've been corrupted by Hel.";
		}
		else if(timer > 30 && timer < 30.4) {
			SwitchAnimation("Smoke Bomb");
			
		}
		else if(timer > 30.4 && timer < 30.5) {
			unknown.SetActive(false);
		    image2.SetActive(false);		
		}
		else if(timer > 30.5 && timer < 30.8) {
			stopTimer= true;
		}
		else if(timer > 30.8 && timer < 32) {
			
			weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y+0.005f, weapon.transform.position.z);
			tunic.transform.position = new Vector3(tunic.transform.position.x, tunic.transform.position.y+0.005f, tunic.transform.position.z);
			potion.transform.position = new Vector3(potion.transform.position.x, potion.transform.position.y+0.005f, potion.transform.position.z);
		}
		else if(timer > 32 && timer < 32.4) {
			weapon.SetActive(false);
			tunic.SetActive(false);
			potion.SetActive(false);
			stopTimer = true;	
            blockingCollider1.SetActive(false);
		}
		else if(timer > 32.5 && timer < 34.5) {
			resumeTut.isTrigger = false;
			FollowPlayer.stopFocus = true;
			transform.position = new Vector3(9.36f, -17.66f, -10.0f);
			chat.text = "Lich: You in time will serve Hel, as will this everyone here!";
            image2.SetActive(true);	
			blockingCollider2.SetActive(true);
			Starter.move = false;
			if(dummy == false) {
			person.transform.position = new Vector2(1.24f, -18.7f+2f);
			}
			dummy = true;
		}
		else if(timer > 35.5 && timer < 36.5) {
			frozen.enabled = true;
			SwitchAnimationFrozen("Frozen");
		}
		else if(timer > 36.5 && timer < 37.5) {
			FollowPlayer.stopFocus = false;
			Lich.SetActive(true);
			Person.SetActive(false);
			image2.SetActive(false);
			Starter.move = true;
		}
         colliders = Physics2D.OverlapCircle(person.transform.position, 0.0f);
         if (colliders == resumeTut)
         {
             stopTimer = false;
			 timer = 32.5f;
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
			chat.text = "Unknown: Not yet... Not here son. We have a competion to save.";
            image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;
		}
		else if(option == 2 || option == 3) {
			image3.SetActive(false);
			chat.text = "Unknown: I know where you came from, the fate of this competition is in your hands.";
            image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;
		}
		else if(option == 4) {
			image3.SetActive(false);
			chat.text = "Unknown: You just have to come with me son, we have a competition to save.";
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
		if(tipsTimer3 > 0f && tipsTimer3 < 2.3f ) {	
			header.text = "Inventory";
			tooltip.text = "To equip items and check your stats you will need to open your inventory using the I button. ";
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		else if(tipsTimer3 > 6f && tipsTimer3 < 8.3f ) {	
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
   void SwitchAnimationFrozen(string layer) {
     for (int i = 0; i < frozen.layerCount; i++)
     {
         frozen.SetLayerWeight(i, 0);
     }

     frozen.SetLayerWeight(frozen.GetLayerIndex(layer), 1);
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
