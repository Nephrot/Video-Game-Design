using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	private static UIManager instance;
	public static UIManager MyInstance {
		get {
			if (instance == null) {
				instance = FindObjectOfType<UIManager>();
			}
			return instance;
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
