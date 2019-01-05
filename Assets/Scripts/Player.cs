using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	[SerializeField]
	public Animator animator;
	[SerializeField]
	public Rigidbody2D rb;
	[SerializeField]
	public Rigidbody2D personrb;
	[SerializeField]
	private Stats health;
	private float healthValue = 100;
	private float maxHealth = 100;
	[SerializeField]
	private Stats mana;
	[SerializeField]
	Sprite outOfMana;
	[SerializeField]
	Sprite casting;
	[SerializeField]
	Sprite regular;
	private float manaValue = 50;
	private float maxMana = 100;
	[SerializeField]
	private Stats stamina;
	private float staminaValue = 100;
	private float maxStamina = 100;
	public float waitTime = 1f;

	public float fireballLasts = 3f;
	public GameObject fireballObject;
	public GameObject dashObject;
	public Image fireballIcon;
	float timer;
	float secondTimer = 3f;
	float thirdTimer = 0.5f;
	public float dashLasts = 0.5f;
	[SerializeField]
	public SpriteRenderer m_SpriteRenderer;
	public SpriteRenderer dash;
	Vector3 mousePos;
	public Animation dashAnimation;
	// Use this for initialization
	float time11;
	float time21;
	float time12;
	float time22;
	float time13;
	float time23;
	float time14;
	float time24;
	bool isTap1 = false;
	bool isTap2 = false;
	bool isTap3 = false;
	bool isTap4 = false;
	private bool isOpen = false;
	void Start () {
		health.createStat (healthValue, maxHealth);
		mana.createStat (manaValue, maxMana);
		stamina.createStat (staminaValue, maxStamina);
	}

	// Update is called once per frame
	void Update () {
		regen ();
		changeIcon ();
		GetInput ();
		
		
	}

	void GetInput () {
		if (Input.GetKeyDown (KeyCode.I)) {
			health.CurrentValue -= 10;
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			health.CurrentValue += 10;
		}
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
		if (Input.GetKeyDown (KeyCode.Alpha1)) {

			if (mana.currentValue >= 40 && secondTimer > fireballLasts) {
				secondTimer = 0f;
				m_SpriteRenderer.sortingLayerName = "InFrontOfScene";
				fireballObject.transform.position = transform.position;
				mana.currentValue -= 40;
				mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				fireballObject.transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - fireballObject.transform.position);

			} else if (mana.currentValue < 40) {
				print ("Out of mana");
			} else {
				print ("You haven't finished casting the ability!");
			}

		}
		Dash ();

		if (secondTimer > fireballLasts) {
			m_SpriteRenderer.sortingLayerName = "BehindOfScene";
		}
		secondTimer += Time.deltaTime;
		rb.velocity = new Vector2 (mousePos.x * 3, mousePos.y * 3);

	}
	void changeIcon () {
		if (mana.currentValue < 40) {
			fireballIcon.sprite = outOfMana;
		} else if (secondTimer < fireballLasts) {
			fireballIcon.sprite = casting;
		} else {
			fireballIcon.sprite = regular;
		}
	}
	void regen () {
		timer += Time.deltaTime;
		if (timer > waitTime) {
			mana.CurrentValue += 10;
			stamina.CurrentValue += 10;
			timer = 0f;

		}
	}

	void Dash () {
		thirdTimer += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.W)) // when mouse is clicked
		{
			if (isTap1 == true) {
				time11 = Time.time;
				isTap1 = false;

				if (time11 - time21 < 0.2f) // interval between two clicked
				{
					if (stamina.currentValue >= 40) {
						
						thirdTimer = 0f;
						dashObject.transform.position = transform.position;
						dash.sortingLayerName = "InFrontOfScene";
						personrb.velocity = new Vector2 (0.0f, 50.0f);
						stamina.currentValue -= 40;
					} else {
						print ("Out Of Stamina");
					}
				}
			}
		} else // first of all, enter here because the mouse is not clicked
		{
			if (isTap1 == false) {
				time21 = Time.time;
				isTap1 = true;
				if (thirdTimer > dashLasts) {
					dash.sortingLayerName = "BehindOfScene";
				}

			}
		}
		if (Input.GetKeyDown (KeyCode.S)) // when mouse is clicked
		{
			if (isTap2 == true) {
				time12 = Time.time;
				isTap2 = false;

				if (time12 - time22 < 0.2f) // interval between two clicked
				{
					if (stamina.currentValue >= 40) {
						thirdTimer = 0f;
						dashObject.transform.position = transform.position;
						dash.sortingLayerName = "InFrontOfScene";
						personrb.velocity = new Vector2 (0.0f, -50.0f);
						stamina.currentValue -= 40;
					} else {
						print ("Out Of Stamina");
					}
				}
			}
		} else // first of all, enter here because the mouse is not clicked
		{
			if (isTap2 == false) {
				time22 = Time.time;
				isTap2 = true;
				if (thirdTimer > dashLasts) {
					dash.sortingLayerName = "BehindOfScene";
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.A)) // when mouse is clicked
		{
			if (isTap3 == true) {
				time13 = Time.time;
				isTap3 = false;

				if (time13 - time23 < 0.2f) // interval between two clicked
				{
					if (stamina.currentValue >= 40)
					thirdTimer = 0f;
					dashObject.transform.position = transform.position;
					dash.sortingLayerName = "InFrontOfScene";
					personrb.velocity = new Vector2 (-50.0f, 0.0f);
					stamina.currentValue -= 40;
				} else {
					print ("Out Of Stamina");
				}
			}
		}
	    else // first of all, enter here because the mouse is not clicked
    	{
		if (isTap3 == false) {
			time23 = Time.time;
			isTap3 = true;
			if (thirdTimer > dashLasts) {
				dash.sortingLayerName = "BehindOfScene";
			}

		}
	}
	if (Input.GetKeyDown (KeyCode.D)) // when mouse is clicked
	{
		if (isTap4 == true) {
			time14 = Time.time;
			isTap4 = false;

			if (time14 - time24 < 0.2f) // interval between two clicked
			{
				if (stamina.currentValue >= 40) {
					thirdTimer = 0f;
					dashObject.transform.position = transform.position;
					dash.sortingLayerName = "InFrontOfScene";
					personrb.velocity = new Vector2 (50.0f, 0.0f);
					stamina.currentValue -= 40;
				} else {
					print ("Out Of Stamina");
				}
			}
		}
	} else // first of all, enter here because the mouse is not clicked
	{
		if (isTap4 == false) {
			time24 = Time.time;
			isTap4 = true;
			if (thirdTimer > dashLasts) {
				dash.sortingLayerName = "BehindOfScene";				
			}

		}
	}
	if (thirdTimer > dashLasts) {
				dash.sortingLayerName = "BehindOfScene";
	}
}
}