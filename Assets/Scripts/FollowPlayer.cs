﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object

    public static bool stopFocus = false;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    public static GameObject preferredPlayer;
    // Use this for initialization
    void Start () 
    {
        if(player == null) {
            player = preferredPlayer;
        }
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }
    
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        if(!stopFocus) {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
        }
    }
}
