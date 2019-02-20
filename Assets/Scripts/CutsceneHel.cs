using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CutsceneHel : MonoBehaviour {
    System.Random rand = new System.Random ();
    // Start is called before the first frame update
    [SerializeField]
    GameObject image2;
    [SerializeField]
    GameObject image3;

    [SerializeField]
    Text chat;
    [SerializeField]
    Camera camera;
    float timer;
    [SerializeField]
    GameObject villains;
    [SerializeField]
    GameObject disappear;
    [SerializeField]
    GameObject jorge;
    bool pressed = false;
    bool pressed2 = false;
    public GameObject lich;
    GameObject instant;
    [SerializeField]
    GameObject lichGroup;
    [SerializeField]
    GameObject counter;
    GameObject health;
    [SerializeField]
    public Stats healthValue;
    public GameObject slime;
    public static Stats healthSomething;
    bool stopTimer;
    public static int counter2 = 0;
    public GameObject healthBar;

    public float timerSlime;
    public GameObject instant2;
    public GameObject boss;

    public GameObject ice;

    public float timerIce;

    public Stats healt;

    public float regTimer;

    public GameObject lichActive;

    public GameObject lichSummon;

    public GameObject lichActive2;

    public GameObject lichSummon2;

    public GameObject fenrir;

    public Stats bossBar;

    public GameObject gridLock;

    public GameObject terminal;
    public static GameObject terminalHeld;
    public GameObject journal;
    public static GameObject journalHeld;

    public static bool terminalActive = false;
    public InputField terminal1;
    public InputField terminal2;
    public InputField terminal3;

    void Start () {
        terminalActive = true;
        lichSummon.SetActive (false);
        healthBar.SetActive (false);
        healthValue.createStat (100, 100);
        Starter.musicFollow = false;
        counter.SetActive (false);
        chat.text = "Jorge: He's here, summon the liches, HE CANNOT HAVE THE LEAP REPORT!";
        image2.SetActive (true);
        image3.SetActive (false);
        FollowPlayer.stopFocus = true;
        transform.position = new Vector3 (transform.position.x, transform.position.y - 2, -10.0f);
        CutsceneTutorial.personHeld.transform.position = new Vector2 (-1, -4);
        CutsceneTutorial.personHeld.GetComponentInChildren<Rigidbody2D> ().velocity = new Vector2 (0, 0);
        Starter.move = false;
        FollowPlayer.preferredPlayer = CutsceneTutorial.personHeld;
        lichGroup.SetActive (false);
        AiLich.switchCharacter = true;
        AiLich.dontCare = true;
        journal.SetActive (false);
        gridLock.SetActive (false);
        terminalActive = true;
        terminal.SetActive (false);
        lichActive2.SetActive(false);
        lichSummon2.SetActive(false);
        // lich.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        //    print(timer);

        timerSlime += Time.deltaTime;
        regTimer += Time.deltaTime;
        timerIce += Time.deltaTime;
        if (regTimer > 4) {
            healt.CurrentValue += 10;
            regTimer = 0;
        }
        // print (timerSlime + " : Timer Slime");

        //  print(counter2);
        if (counter2 == 1) {
            counter2++;
            timer = 13.1f;
            stopTimer = false;
        }
        AiLich.dontCare = true;
        if (!stopTimer) {
            timer += Time.deltaTime;
        }
        if (timer > 4 && timer < 8) {
            chat.text = "Hel: I will protect it my liege, they will not have their hands on such a tool.";
        } else if (timer > 8 && timer < 12) {
            if (!pressed) {
                instant = Instantiate (disappear);
                pressed = true;
                instant.transform.position = jorge.transform.position;
            }
            FollowPlayer.stopFocus = false;
            Starter.move = true;
            // transform.position = new Vector3(transform.position.x, transform.position.y+4, -10.0f);
            image2.SetActive (false);
            villains.SetActive (false);
            lichGroup.SetActive (true);
            stopTimer = true;
        } else if (timer > 13 && timer < 17) {
            if (timerSlime > 7) {
                instant2 = Instantiate (slime);
                instant2.transform.position = new Vector2 (-11f, -7);
                timerSlime = 0;
            }
            if (timerIce > 3) {
                instant2 = Instantiate (ice);
                timerIce = 0;
            }
            chat.text = "Lich King: No, this isn't possible this is Hel's Realm, stop him!";
            image2.SetActive (true);
            healthBar.SetActive (true);
          //  print (timer);
        } else if (timer > 17 && timer < 18) {
            if (timerSlime > 7) {
                instant2 = Instantiate (slime);
                instant2.transform.position = new Vector2 (-11f - rand.Next (0, 3), -7);
                timerSlime = 0;
            }
            if (timerIce > 1) {
                instant2 = Instantiate (ice);
                timerIce = 0;
            }
          //  print (timer);
            stopTimer = true;
            image2.SetActive (false);
        } else if (timer > 19.1f && timer < 23.1f) {
            chat.text = "Hel: You will not make it out of here alive, Fenrir!";
            image2.SetActive (true);
            lichActive.SetActive (false);
        } else if (timer > 23.1f && timer < 27.1f) {
            chat.text = "Unknown: She is going to keep throwing minions at you, keep attacking until she is weakened.";
            image2.SetActive (true);
            lichActive.SetActive (false);
        } else if (timer > 27.1f && timer < 31.1f) {
            chat.text = "Unknown: We have to stop her, use the gridlock static object in your terminal, gridlock.break() being the method.";
            image2.SetActive (true);
            lichActive.SetActive (false);
        } else if (timer > 27.1f && timer < 31.1f) {
            chat.text = "Unknown: Watch out for Fenrir.";
            image2.SetActive (true);
            lichActive.SetActive (false);
        } else if (timer > 31.1f && timer < 32.1) {
            if (timerSlime > 7) {
                instant2 = Instantiate (fenrir);
                instant2.transform.position = new Vector2 (9f, CutsceneTutorial.personHeld.transform.position.y);
                timerSlime = 0;
            }
            image2.SetActive (false);
            lichActive.SetActive (false);
        } else if (timer > 32.1 && timer < 37.1) {
            if (timerSlime > 7) {
                instant2 = Instantiate (fenrir);
                instant2.transform.position = new Vector2 (9f, CutsceneTutorial.personHeld.transform.position.y);
                timerSlime = 0;
            }
            stopTimer = true;
            lichActive.SetActive (false);
        } else if(timer > 39f && timer < 40.6) {
            lichSummon2.SetActive(true);
        } else if(timer > 40.6 && timer < 45.6) {
            lichActive2.SetActive(true);
            if (timerSlime > 7) {
                instant2 = Instantiate (slime);
                instant2.transform.position = new Vector2 (-11f - rand.Next (0, 3), -7);
                instant2 = Instantiate (fenrir);
                instant2.transform.position = new Vector2 (9f, CutsceneTutorial.personHeld.transform.position.y);
                timerSlime = 0;
            }
            if (timerIce > 1) {
                instant2 = Instantiate (ice);
                timerIce = 0;
            }
        } else if(timer > 45.6) {
            image2.SetActive(false);
            stopTimer = true;
            if (timerSlime > 7) {
                // instant2 = Instantiate (slime);
                // instant2.transform.position = new Vector2 (-11f - rand.Next (0, 3), -7);
                instant2 = Instantiate (fenrir);
                instant2.transform.position = new Vector2 (9f, CutsceneTutorial.personHeld.transform.position.y);
                timerSlime = 0;
            }
            if (timerIce > 1) {
                instant2 = Instantiate (ice);
                timerIce = 0;
            }
            
        } 


        if (bossBar.CurrentValue < 500 && timer > 13 && timer < 18) {
            lichActive.SetActive (false);
            Destroy (lichActive);
            lichSummon.SetActive (true);
            gridLock.SetActive (true);
            timer = 19.1f;
            stopTimer = false;
        }
        if(bossBar.CurrentValue <= 0) {
             image2.SetActive (true);
             chat.text = "Hel: Stop, Stop, don't you see you're disturbing the peace, have the leap report and leave us!";
             timer = 50;
        }
        // float distanceToTarget2 = Vector3.Distance (instant2.transform.position, boss.transform.position);

        AiLich.switchCharacter = true;
        // if (timerSlime > 7) {
        //     instant2 = Instantiate (slime);
        //     instant2.transform.position = new Vector2 (-11f, -7);
        //     timerSlime = 0;
        // }
        IceAttack.healthHeld = healt;
        terminalHeld = terminal;
        journalHeld = journal;
    }

    void LateUpdate() {
        if(Input.GetKeyDown(KeyCode.Return)) {
            if (terminal3.text == "}" && terminal1.text == "void Start() {" && terminal2.text == "gridlock.break();") {
                timer = 40f;
                stopTimer = false;
                image2.SetActive (true);
                chat.text = "Unknown: You are a natural at this!";
                gridLock.SetActive (false);
               
            } else if (terminal2.text != "gridlock.break();") {
                image2.SetActive (true);
                chat.text = "Unknown: //nC; ( gridlock.break(); ) // is a static object you don't have to create an object to make it";
            } else if (terminal3.text != "}") {
                image2.SetActive (true);
                chat.text = "Unknown: Did you add a break system correctly, use //nC; ( } ) //";
            } else if (terminal1.text != "void Start() {") {
                image2.SetActive (true);
                chat.text = "Unknown: Remember to start off a method do //nC; ( void Start() { ) //";
            } else {
                chat.text = "Unknown: What have you done nothing here is right";
            }
            print("Input Works");

        }
    }
}