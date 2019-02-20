using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiBoss1 : MonoBehaviour
{

    public Stats health;
    public int counter = 0;
    public float timer; 
    public float waitTime = 1.3f;
    System.Random rand = new System.Random ();
    public GameObject counters;
    public Transform target;
     public Text counterText;

    // Start is called before the first frame update
    void Start()
    {
        health.createStat(1000, 1000);
    }

    // Update is called once per frame
    void Update()
    {
       var sprite = GetComponent<SpriteRenderer> ();
       sprite.sortingOrder = Mathf.RoundToInt (transform.position.y * -10f);
         //  print(health.currentValue);
          timer += Time.deltaTime;
    }

    void OnMouseOver () {
       target = CutsceneTutorial.personHeld.transform;
       //click object multiple times to turn on or off. 
       //if mouse is being clicked else where, then noting should happen.
       float distanceToTarget = Vector3.Distance (transform.position, target.position);
       print(distanceToTarget);
          if (timer > 1.2f) {
             if (Input.GetMouseButton (0)) {
                if (distanceToTarget < 5) {
                   int damage = rand.Next(3, 5);
                   counters.SetActive (true);
                   //  if (audioThing.clip != battle) {
                   //     audioThing.clip = battle;
                   //     audioThing.Play ();
                   //  }
                   //  CutsceneTutorial.musicTimer = 0;
                   CutsceneTutorial.timerCounter = 0;
                   counter++;
                   counterText.text = counter + "";
                   health.CurrentValue -= damage;
                   string damageSTR = damage + "";
                   print (damageSTR);
                   timer = 1f;
                   PopupTextController.CreateFloatingText(damageSTR, transform);
                   print(counterText.text);
                //    Vector3 moveDirection = target.position - transform.position;
                //    if (!isWarrior) {
                //       rb.AddForce (moveDirection.normalized * -700f);
                //    }
                }
             }
       }
    }
}
