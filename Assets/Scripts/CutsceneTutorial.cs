using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class CutsceneTutorial : MonoBehaviour {

    public static GameObject personHeld;
	public static GameObject InventoryHeld;
	public GameObject InventoryHolder;

	public GameObject personHolder;
	// Use this for initialization
	public GameObject finishTutorial;
	public GameObject gamesCutscene;
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
	public Animator animatorUnknown;
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
    
	Collider2D dummy2;
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
	public static float musicTimer;
	float tipsTimer2;
	float tipsTimer3;
	float tipsTimer4;
	float tipsTimer5;
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
	  public GameObject stopCollider;
	  bool timer4bool = false;
	    bool timer5bool = false;
		public bool brokeWall;

	  public GameObject unknown2;

	  public Collider2D collider3;
	  
	  public InputField terminal1;
	  public InputField terminal2;
	  public InputField terminal3;
	  public InputField terminal4;

     [SerializeField]
	  public GameObject fixedWall;
	      [SerializeField]
	  public GameObject brokenGame;
	  public static float timerCounter;
     [SerializeField]
	  GameObject Health;
	  public static GameObject HealthHeld;
	void Start () {
      image3.SetActive(false);
	  explosion.SetActive(false);
	  Lich.SetActive(false);
	  frozen.enabled = false;
	  blockingCollider2.SetActive(false);
	  unknown2.SetActive(false);
	  fixedWall.SetActive(false);
	   finishTutorial.SetActive(false);
	}
	
	
	// Update is called once per frame
	void Update () {
		// print(timer);
		// print(stopTimer);
		personHeld = personHolder;
		InventoryHeld = InventoryHolder;
		HealthHeld = Health;
        timerCounter += Time.deltaTime;
		musicTimer += Time.deltaTime;
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
		if(timer4bool == true) {
		tipsTimer4 += Time.deltaTime;
		}
		if(timer5bool == true) {
		tipsTimer5 += Time.deltaTime;
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
            if(distance < -8) {
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
	     	chat.text = "Unknown: I'll be back, deal with the Lich's here they've been corrupted by the game.";
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
		else if(timer > 36.5 && timer < 37.2) {
			FollowPlayer.stopFocus = false;
			Lich.SetActive(true);
			Person.SetActive(false);
			image2.SetActive(false);
			Starter.move = true;
			stopCollider.SetActive(false);
			timer4bool = true;
			
		}
		else if(timer > 37.2 && timer < 37.9) {
			stopTimer = true;
		}
		else if(timer > 38 && timer < 38.5) {
			gamesCutscene.SetActive(false);
		    unknown2.SetActive(true);
			SwitchUnknownAnimation("Smoke Bomb");
		}
		else if(timer > 38.5 && timer < 42) {
			chat.text = "Unknown: I am back... missed me right, anyways looks like a glitch.";
            image2.SetActive(true);	
			SwitchUnknownAnimation("Idle");
			
		}
		else if(timer > 42 && timer < 46) {
             chat.text = "Unknown: We can fix this with the terminal, a few parts I fastened up.";
		}
		else if(timer > 46 && timer < 50) {
			chat.text = "Unknown: This isn't your regular computer, it changes the very game your in.";
		}
		else if(timer > 50 && timer < 54) {
			chat.text = "Unknown: We use it as a weapon against him, techology above his control";
		}
		else if(timer > 54 && timer < 58) {
			chat.text= "Unknown: The prophet told me you would be the one to liberate us and so here.";
		}
		else if(timer > 58 && timer < 60) {
			chat.text = "Unknown: Use it.";
			timer5bool = true;
		}
		else if(timer > 60 && timer < 66) {
			image2.SetActive(false);
			chat1.text = "-) I need answers now!";
			chat2.text = "-) States are today, help me get out of here!";
			chat3.text = "-) ...";
			chat4.text = "-) Looks interesting, how do I use it.";
			image3.SetActive(true);

		}
		else if(timer > 70 && timer < 74) {

		}
		else if(timer > 74 && timer < 78) {
		 chat.text= "Unknown: To start off create a variable, look in your journal.";
		}

        if(Input.GetKeyDown(KeyCode.Return) && Starter.terminal) {
			print("Works");
           if(terminal4.text == "}" && terminal1.text.Substring(0, 4) == "Wall" && terminal1.text.Substring(terminal1.text.Length - 13) == "= new Wall();"
		   && terminal2.text == "void Start() {" && terminal3.text == (terminal1.text.Substring(5,terminal1.text.Length - 19) + ".destroy();")) {
               chat.text = "Unknown: You did it, we have to go we have to get that leap report, follow me";
			   fixedWall.SetActive(true);
			   brokenGame.SetActive(false);
			   finishTutorial.SetActive(true);
			   
		   }
		   else if(terminal4.text != "}") {
			   chat.text = "Unknown: Did you add a break system correctly, use //nC; (}) //";
		   }
		   else if(terminal1.text.Substring(0, 4) != "Wall" || terminal1.text.Substring(terminal1.text.Length - 13) != "= new Wall();") {
			   chat.text = "Unknown: Wall isn't defined correctly, the object is Wall";
			   print(terminal1.text.Substring(terminal1.text.Length - 13));
		   }
		   else if(terminal2.text != "void Start() {") {
               chat.text = "Unknown: Your start menthod isnt defined correctly, n// C/. (void Start() {) //";
		   }
		   else if(terminal3.text != (terminal1.text.Substring(5,terminal1.text.Length - 19) + ".destroy();")) {
			   chat.text = "Unknown: .destroy() method is defined incorrectly";
			   print((terminal1.text.Substring(5,terminal1.text.Length - 19) + ".destroy();"));
			   print(terminal1.text.Length - 18);
		   }
		   else {
			   chat.text = "Unknown: What have you done nothing here is right";
		   }
		   print(timer);
		}
         colliders = Physics2D.OverlapCircle(person.transform.position, 0.0f);
         if (colliders == resumeTut)
         {
             stopTimer = false;
			 timer = 32.5f;
		 }
          if (colliders == collider3)
         {
             stopTimer = false;
			 timer = 38f;
		 }
		 if (colliders == finishTutorial.GetComponentInChildren<BoxCollider2D>())  {
			DontDestroyOnLoad(InventoryHeld);
            SceneManager.LoadScene("Overworld");
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
		if(option == 1 && timer < 15) {
			image3.SetActive(false);
			chat.text = "Unknown: Not yet... Not here son. We have a competion to save.";
            image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;
		}
		else if((option == 2 || option == 3) && timer < 15) {
			image3.SetActive(false);
			chat.text = "Unknown: I know where you came from, the fate of this competition is in your hands.";
            image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
			option = 0;

		}
		else if(option == 4 && timer < 15) {
			image3.SetActive(false);
			chat.text = "Unknown: You just have to come with me son, we have a competition to save.";
			image2.SetActive(true);
			timer = 16f;
			stopTimer= false;
		 	option = 0;
			
		}
		else if(option == 1) {
			image3.SetActive(false);
			chat.text = "Unknown: We are stuck in the game you created for the competition, I'll explain it later";
			image2.SetActive(true);
			option = 0;
			timer = 70;
			stopTimer = false;
		}
		else if(option == 2) {
			image3.SetActive(false);
			chat.text = "Unknown: You can only help yourself son, you have to get out of this game";
			image2.SetActive(true);
			option = 0;
			timer = 70;
			stopTimer = false;
		}
		else if(option == 3) {
			image3.SetActive(false);
			chat.text = "Unknown: And to think you were so talkative earlier, hmm";
			image2.SetActive(true);
			option = 0;
			timer = 70;
			stopTimer = false;
		}
		else if(option == 4) {
			image3.SetActive(false);
			chat.text = "C://tsa//helpme.csv: Pre-s, the, T, but0hn";
			image2.SetActive(true);
			option = 0;
			timer = 70;
			stopTimer = false;
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
		if(tipsTimer4 > 0f && tipsTimer4 < 2.3f ) {	
			header.text = "Attack";
			tooltip.text = "To attack targets hold the crosshair on the enemy, make sure the sword is equipped.";
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		else if(tipsTimer4 > 6f && tipsTimer4 < 8.3f ) {	
			image.transform.position = new Vector3(image.transform.position.x+5, image.transform.position.y, image.transform.position.z);
		}
		if(tipsTimer4 > 10f && tipsTimer4 < 12.3f ) {	
			header.text = "Dash";
			tooltip.text = "To evade press space in the direction you wish to dash to.";
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		else if(tipsTimer4 > 16f && tipsTimer4 < 18.3f ) {	
			image.transform.position = new Vector3(image.transform.position.x+5, image.transform.position.y, image.transform.position.z);
		}
		if(tipsTimer5 > 0f && tipsTimer5 < 2.3f ) {	
			header.text = "Terminal";
			tooltip.text = "Press T to open the terminal and start messing with the game's base code.";
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		else if(tipsTimer5 > 6f && tipsTimer5 < 8.3f ) {	
			image.transform.position = new Vector3(image.transform.position.x+5, image.transform.position.y, image.transform.position.z);
		}
		if(tipsTimer5 > 10f && tipsTimer5 < 12.3f ) {	
			header.text = "Journal";
			tooltip.text = "Press J to look in your journal for helpful notes about the terminal.";
			image.transform.position = new Vector3(image.transform.position.x-5, image.transform.position.y, image.transform.position.z);
		}
		else if(tipsTimer5 > 16f && tipsTimer5 < 18.3f ) {	
			image.transform.position = new Vector3(image.transform.position.x+5, image.transform.position.y, image.transform.position.z);
		}
	}
	void SwitchAnimation(string layer) {
     for (int i = 0; i < animator.layerCount; i++)
     {
         animator.SetLayerWeight(i, 0);
		 animatorUnknown.SetLayerWeight(i, 0);
     }
     animatorUnknown.SetLayerWeight(animatorUnknown.GetLayerIndex(layer), 1);
     animator.SetLayerWeight(animator.GetLayerIndex(layer), 1);
   }
   void SwitchUnknownAnimation(string layer) {
	 for (int i = 0; i < animatorUnknown.layerCount; i++)
     {
		 animatorUnknown.SetLayerWeight(i, 0);
     }
     animatorUnknown.SetLayerWeight(animatorUnknown.GetLayerIndex(layer), 1);
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
