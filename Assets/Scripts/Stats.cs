using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

	// Use this for initialization
	private Image content;

	private float lerpSpeed = 3;
	public float max { get; set; }
	private float currentFill; 
	public float currentValue;
	public float CurrentValue {
		get {
			return currentValue;
		}
		set {
			if(value > max) {
				currentValue = max;
			}
			else if(value < 0) {
				currentValue = 0;
			}
			else {
			    currentValue = value;	
			}
			
		}
	}
	

	void Start () {
		
		content = GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(content.fillAmount != (currentValue/max)) {
			content.fillAmount = Mathf.Lerp(content.fillAmount, (currentValue/max), Time.deltaTime * lerpSpeed);
		}
	
	}

	public void createStat (float currentValue, float max) {
      this.max = max;
	  this.currentValue = currentValue;
	}
}
