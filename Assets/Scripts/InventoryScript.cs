using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {
	private static InventoryScript instance;
	public static InventoryScript Instance 
	{
		get {
			if (instance == null) {
				instance = FindObjectOfType<InventoryScript>();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
