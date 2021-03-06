﻿ using System.Collections;
 using UnityEngine.Audio;
 using UnityEngine.UI;
 using UnityEngine;
 public class AiLich : MonoBehaviour {

    GameObject warning;
    public GameObject death;
    public Transform[] patrolPoints;
    public float speed;

    public AudioSource audioThing;
    public AudioClip idle;
    public AudioClip battle;
    Transform currentPatrolPoint;

    int currentPatrolIndex;
    [SerializeField]
    public bool isWarrior = false;
    public Transform target;
    public Animator animator;
    public float chaseRange;
    [SerializeField]
    public Rigidbody2D rb;
    public int health = 100;
    public GameObject lich;
    public float timer;
    [SerializeField]
    public string option;
    public float timer2;
    public float waitTime = 1.3f;
    System.Random rand = new System.Random ();
    private static FloatingText prefab;
    bool dummy = false;
    public Starter starter;
    [SerializeField]
    public float timerAttack;
    public bool pressed = false;
    public GameObject ice;
    GameObject instance;
    public GameObject warningPrefab;
    public Rigidbody2D rbT;
    public EquipmentSlot equipmentSlot;
    public Item item;
    public GameObject healthmenu;
    public SpriteRenderer healthBar;
    public Sprite healthBar1;
    public Sprite healthBar2;
    public Sprite healthBar3;
    public Sprite healthBar4;
    public Sprite healthBar5;
    public Sprite healthBar6;
    public Sprite healthBar7;
    public Sprite healthBar8;
    public Sprite healthBar9;
    public Sprite healthBar10;
    public Sprite healthBar11;
    public Sprite healthBar12;
    public Sprite healthBar13;
    public Sprite healthBar14;
    public GameObject instantHealth;
    public int counter = 0;
    public Image image;
    public Sprite novice;
    public Sprite adept;
    public Sprite skillful;
    public Sprite master;

    public GameObject counters;
    public Text counterText;

    public static bool dontCare = false;

    public static bool switchCharacter = false;
    public Stats healthPerson;

    public CutsceneHel cutsceneHel;

    public GameObject enemyObject;
    public static bool bool2 = false;
    void Start () {
       currentPatrolIndex = 0;
       currentPatrolPoint = patrolPoints[currentPatrolIndex];
       warning = null;
       if (switchCharacter) {
          target = CutsceneTutorial.personHeld.transform;
          rbT = CutsceneTutorial.personHeld.GetComponentInChildren<Rigidbody2D> ();
       }
    }
    void Update () {
       print(switchCharacter);
       if (switchCharacter && bool2) {
          target = CutsceneTutorial.personHeld.transform;
          rbT = CutsceneTutorial.personHeld.GetComponentInChildren<Rigidbody2D> ();
       }
       if (dummy == false) {
          SwitchAnimation (option);
          instantHealth = Instantiate (healthmenu);
          counters.SetActive (false);
          dummy = true;
       }
       instantHealth.transform.position = new Vector2 (transform.position.x, transform.position.y + 1.7f);
//       print (health);
       timer2 += Time.deltaTime;
       if (health == 100) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar1;
       } else if (health > 90) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar2;
       } else if (health > 82) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar3;
       } else if (health > 74) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar4;
       } else if (health > 66) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar5;
       } else if (health > 58) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar6;
       } else if (health > 50) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar7;
       } else if (health > 42) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar6;
       } else if (health > 34) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar7;
       } else if (health > 30) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar8;
       } else if (health > 26) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar9;
       } else if (health > 20) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar10;
       } else if (health > 15) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar11;
       } else if (health > 10) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar12;
       } else if (health > 5) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar13;
       } else if (health > 2) {
          instantHealth.GetComponentInChildren<SpriteRenderer> ().sprite = healthBar14;
       }
       float distanceToTarget = Vector3.Distance (transform.position, target.position);
       var sprite = GetComponent<SpriteRenderer> ();

       sprite.sortingOrder = Mathf.RoundToInt (transform.position.y * -10f);
       if (distanceToTarget < 2) {
          if (timer2 > waitTime) {
             if(switchCharacter == true) {
             healthPerson.CurrentValue -= 5;
             }
             else if(switchCharacter == false) {
             starter.health.CurrentValue -= 5;
             }
             
             Vector3 moveDirection = transform.position - target.position;
             rbT.AddForce (moveDirection.normalized * -700f);
             timer2 = 0f;
          }
          Vector3 targetDir = target.position - transform.position;
          float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
          if (timerAttack < 4) {
             SwitchAnimation ("Attack");
          } else if (!isWarrior) {
             SwitchAnimation ("Attack");
          }
          Vector2 velocity = new Vector2 ((transform.position.x - target.position.x) * speed, (transform.position.y - target.position.y) * speed);
          if (timerAttack < 4) {
             rb.velocity = -velocity;
          } else if (!isWarrior) {
             rb.velocity = -velocity;
          }
          animator.SetFloat ("X", -velocity.x);
          animator.SetFloat ("Y", -velocity.y);

          timerAttack += Time.deltaTime;
       } else if (distanceToTarget < chaseRange) {
          Vector3 targetDir = target.position - transform.position;
          timerAttack += Time.deltaTime;
          float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
          if (timerAttack < 4) {
             SwitchAnimation ("Lich Walk");
          } else if (!isWarrior) {
             SwitchAnimation ("Lich Walk");
          }
          Vector2 velocity = new Vector2 ((transform.position.x - target.position.x) * speed, (transform.position.y - target.position.y) * speed);
          if (timerAttack < 4) {
             rb.velocity = -velocity;
          } else if (!isWarrior) {
             rb.velocity = -velocity;
          }
          animator.SetFloat ("X", -velocity.x);
          animator.SetFloat ("Y", -velocity.y);
       } else if (distanceToTarget < chaseRange + 0.01f) {
          SwitchAnimation (option);
       } else {
          SwitchAnimation (option);
          rb.velocity = new Vector2 (0f, 0f);
          if (timerAttack > 3) {
             timerAttack += Time.deltaTime;
          }
       }
       timer += Time.deltaTime;
       healthmenu.transform.position = new Vector2 (transform.position.x, transform.position.y + 1.7f);

       if (health <= 0) {
          counters.SetActive (false);
          death.transform.position = transform.position;
          Instantiate (death);
          Destroy (instantHealth);
          death.transform.position = transform.position;
          Destroy (gameObject);
          if (audioThing.clip != idle) {
             audioThing.clip = idle;
             audioThing.Play ();
          }

       }
       if (timerAttack > 3 && timerAttack < 3.7 && isWarrior) {
          GameObject warningHold = new GameObject();
          if (pressed == false) {
             warningHold = Instantiate (warningPrefab);
           
             pressed = true;
          }
           warningHold.transform.position = new Vector2(transform.position.x, transform.position.y + 2f);
         //  warning.transform.position = new Vector2 (transform.position.x, transform.position.y + 2f);
       }
       if (timerAttack > 3.7 && timerAttack < 4f) {
          pressed = false;
         //  warningHold.transform.position = new Vector2(transform.position.x, transform.position.y + 2f);
       }
       if (timerAttack > 4f && timerAttack < 4.5f && isWarrior) {
          if (pressed == false) {
             if (distanceToTarget < 2) {
                starter.health.CurrentValue -= 20;
             }
             instance = Instantiate (ice);
             instance.transform.position = transform.position;
             pressed = true;
             SwitchAnimation ("Special");
             rb.velocity = new Vector2 (0, 0);
          }
       }
       if (timerAttack > 6f) {
          Destroy (instance);
          pressed = false;
          timerAttack = 0f;
       }
      //  print (CutsceneTutorial.timerCounter > 2);
      //  print (CutsceneTutorial.timerCounter);
       if (CutsceneTutorial.timerCounter > 2) {
          counter = 0;
          counters.SetActive (false);
       }

       if (counter > 30) {
          image.sprite = master;
       } else if (counter > 20) {
          image.sprite = skillful;
       } else if (counter > 10) {
          image.sprite = adept;
       } else {
          image.sprite = novice;
       }
       //  print(health);
       //  print("timer" + timer);
       if (CutsceneTutorial.musicTimer > 8) {
          if (audioThing.clip != idle) {
             audioThing.clip = idle;
             audioThing.Play ();
          }
       }
    }

    void OnMouseOver () {
       //click object multiple times to turn on or off. 
       //if mouse is being clicked else where, then noting should happen.
       float distanceToTarget = Vector3.Distance (transform.position, target.position);
       if (dontCare == false) {
          if (equipmentSlot.Item == item) {
             if (timer > 1.2f) {
                if (Input.GetMouseButton (0)) {
                   if (distanceToTarget < 2) {
                      
                      int damage = rand.Next (3, 5);
                      counters.SetActive (true);
                      if (audioThing.clip != battle) {
                         audioThing.clip = battle;
                         audioThing.Play ();
                      }
                      CutsceneTutorial.musicTimer = 0;
                      CutsceneTutorial.timerCounter = 0;
                      counter++;
                      counterText.text = counter + "";
                      health -= damage;
                      string damageSTR = damage + "";
                      print (damageSTR);
                      timer = 1f;
                      if(dontCare == false) {
                      PopupTextController.CreateFloatingText(damageSTR, transform);
                      }
                      else if(dontCare == true) {
                      PopupTextController.CreateFloatingText(damageSTR, transform);
                      }
                      Vector3 moveDirection = target.position - transform.position;
                      if (!isWarrior) {
                         rb.AddForce (moveDirection.normalized * -700f);
                      }
                      
                   }
                }
             }
          }
       } else if (dontCare == true) {
          if (timer > 1.2f) {
             if (Input.GetMouseButton (0)) {
                if (distanceToTarget < 2) {
                   int damage = rand.Next (3, 5);
                   counters.SetActive (true);
                   //  if (audioThing.clip != battle) {
                   //     audioThing.clip = battle;
                   //     audioThing.Play ();
                   //  }
                   //  CutsceneTutorial.musicTimer = 0;
                   CutsceneTutorial.timerCounter = 0;
                   counter++;
                   counterText.text = counter + "";
                   health -= damage;
                   string damageSTR = damage + "";
                   print (damageSTR);
                   timer = 1f;
                   Vector3 moveDirection = target.position - transform.position;
                   if (!isWarrior) {
                      rb.AddForce (moveDirection.normalized * -700f);
                   }
                   PopupTextController.CreateFloatingText (damageSTR, transform);
                }
             }
          }
       }
    }
    void SwitchAnimation (string layer) {

       for (int i = 0; i < animator.layerCount; i++)

       {

          animator.SetLayerWeight (i, 0);

       }

       animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);

    }
 }