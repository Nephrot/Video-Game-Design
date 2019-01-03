using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalPoints : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	Text totalPoints;
	[SerializeField]
	Slider slider1;
	[SerializeField]
	Slider slider2;
	[SerializeField]
	Slider slider3;
	
	// Update is called once per frame
	void Update () {
		totalPoints.text = (7 - slider1.value - slider2.value - slider3.value) + "";
		
	}
}
