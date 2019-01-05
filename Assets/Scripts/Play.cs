using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour {

	// Use this for initialization
	public Image content;
	public GameObject contentObject;
	float timer = 0f;
	public float wait = 3f;
	private float lerpSpeed = 3;
	bool startTimer = false;
	void Start() {
     contentObject.SetActive(false);
	}
	void Update() {
		if(startTimer) {
		  timer += Time.deltaTime;
	    }
		content.fillAmount += 0.005f;
		print(timer);
		if (timer >= wait) {
            Application.LoadLevel("CharacterCreation");
		}
	}
	public void changeScene() {
		timer = 0f;
		wait = 3f;
		startTimer = true;
		contentObject.SetActive(true);
	    content.fillAmount = 0f;

	}
}
