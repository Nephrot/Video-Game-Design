using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditStats : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	Text stat;
	[SerializeField]
	Text TotalPoints;
	[SerializeField]
	Slider slider;

	int num;
	void Update () {
		if(int.Parse(TotalPoints.text) < 0) {
               TotalPoints.color = Color.red;
		}
		if(int.Parse(TotalPoints.text) > 0) {
               TotalPoints.color = Color.black;
		}
		if(int.Parse(TotalPoints.text) == 0) {
               TotalPoints.color = Color.green;
		}
		stat.text = slider.value + "";
	}
	
}
