 using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 
 public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     public GameObject image;
 
    void Start() {
		image.SetActive(false);
	}
     public void OnPointerEnter(PointerEventData eventData)
     {
         image.SetActive(true);
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
        image.SetActive(false); //Or however you do your color
     }
 }


