using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
    InputField namefield;
	[SerializeField]
	public static string nameCharacter = "hi";
	[SerializeField]
	GameObject nameError;
	[SerializeField]
	GameObject statError;
	[SerializeField]
	GameObject classError;
	[SerializeField]
	Toggle toggle1;
	[SerializeField]
	Toggle toggle2;
	[SerializeField]
	Toggle toggle3;
	[SerializeField]
	Text stat;
	[SerializeField]
	public static string classOf = "something";
	// Update is called once per frame
	void Start () {
		nameError.SetActive(false);
		classError.SetActive(false);
		statError.SetActive(false);
	}
	void Update () {
		nameCharacter = namefield.text;
		if(toggle1.isOn) {
				  classOf = "warrior";
			  }
			  else if(toggle2.isOn) {
				  classOf = "mage";
			  }
			  else if(toggle3.isOn) {
				  classOf = "hunter";
			  }
	  
	}
	public void check () {
		nameError.SetActive(false);
		classError.SetActive(false);
		statError.SetActive(false);
		if(nameCharacter.Length < 1 ) {
             nameError.SetActive(true);  
		}
		else if(int.Parse(stat.text) != 0) {
             statError.SetActive(true);
		}
		else if(!(toggle1.isOn || toggle2.isOn || toggle3.isOn)) {
             classError.SetActive(true);
		}
		else {
              SceneManager.LoadScene("Tutorial");	 
        }

	}
}