using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFenrir : MonoBehaviour
{
    public GameObject Fenrir;
    public bool pressed = false;
    
    public Transform target;
    public Stats health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Fenrir.transform.position = new Vector2(Fenrir.transform.position.x-0.2f,Fenrir.transform.position.y);
        target = CutsceneTutorial.personHeld.transform;
         if(Fenrir.transform.position.x < -9) {
            Destroy(Fenrir);
        }
        var sprite = GetComponent<SpriteRenderer> ();
        sprite.sortingOrder = Mathf.RoundToInt (transform.position.y * -10f);
         float distanceToTarget = Vector3.Distance (Fenrir.transform.position, target.position);
         if(!pressed && distanceToTarget < 2) {
            health.CurrentValue -= 30;
            pressed = true;
        }
        
    }
}
