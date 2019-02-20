using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class IceAttack : MonoBehaviour
{
    // Start is called before the first frame update
    float timer;
    public GameObject ice;
    public Stats health;
    public static Stats healthHeld;
    void Start()
    {
        ice.transform.position = CutsceneTutorial.personHeld.transform.position;
        ice.transform.position = new Vector2(ice.transform.position.x, ice.transform.position.y + 3);
    }

    // Update is called once per frame
    void Update()
    {
        health = healthHeld;
        timer += Time.deltaTime;
        if(timer > .99) {
          if(Math.Abs(CutsceneTutorial.personHeld.transform.position.x - ice.transform.position.x) < 2) {
           if(Math.Abs(CutsceneTutorial.personHeld.transform.position.y - ice.transform.position.y) < 5) {
           health.CurrentValue -= 10;
           }
          } 
          Destroy(ice);
        }
    }
}
