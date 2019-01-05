using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour

{
    GameObject fireball1;
    public Animation fireballAnimation;
    [SerializeField]
    SpriteRenderer coll2;
    public float timer = 0;
    static float wait = 4f;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == ("Wall (1)"))
        {
            print("No");
            coll2.enabled = false;
            
        }
        else
        {
            print("Hah");
        }
      
    }
    public void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(timer == 4)
            {
                coll2.enabled = true;
            }
        }
    }

}
