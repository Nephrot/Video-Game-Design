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
	Text health;
	[SerializeField]
	Text mana;
	[SerializeField]
	Text stamina;
	[SerializeField]
	public static string classOf = "something";
	public static int health1 = 0;
	public static int mana2 = 0;
	public static int stamina3 = 0;
	
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
			  health1 = int.Parse(health.text);
			  mana2 = int.Parse(mana.text);
			  stamina3 = int.Parse(stamina.text);
	  
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