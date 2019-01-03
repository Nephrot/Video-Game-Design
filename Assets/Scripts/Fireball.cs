using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Fireball : MonoBehaviour {
    
    private Vector3 target;
    private Rigidbody2D myRigidBody;
    [SerializeField]
	public Animation fireballAnimation;
    private Vector2 mouse;

    public float waitTime = 3f;
    float timer;
    void Start () {
        fireballAnimation.Play();
        
    }
	public void rotateFireball () {
		 transform.Rotate(Vector3.forward * -90);
    	}
    }
	

