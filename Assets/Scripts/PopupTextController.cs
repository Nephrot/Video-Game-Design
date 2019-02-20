using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopupTextController : MonoBehaviour {

 //static methods require static references
 private static GameObject popupText;
 private static RectTransform parent;
  private static GameObject ui2;
 private static float min = -.5f, max = .5f;

  public GameObject canvas;
   public GameObject popupText2;
    public GameObject ui;

 private void Start()
 {
  //set the parent to the ui group
  parent = canvas.transform.GetComponent<RectTransform>();
  popupText = popupText2;
  ui2 = ui;
 }

 public static void CreateFloatingText(string text, Transform location)
 {
  //find if null
   //create an instance of the text prefab
   GameObject instance = Instantiate(ui2);
   
   //convert it's called location to screenspace
   Vector2 screenPos = Camera.main.WorldToScreenPoint(
   new Vector2(location.position.x + Random.Range(min,max), location.position.y));
   //parent that instance to the canvas
   instance.transform.SetParent(parent, false);
   //set the instance's position to screenPos
   if(AiLich.dontCare == false) {
   instance.transform.position = screenPos;
   }
   else if(AiLich.dontCare == true) {
   instance.transform.position = location.position;
   }
   //set the text to passed
   instance.GetComponentInChildren<Text>().text = text;

   //get anim clip length and destroy it at end of clip
   Animator anim = instance.GetComponentInChildren<Animator>();
   //grabs current animator clip and store it in array
   AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
   Destroy(instance, clipInfo[0].clip.length);
 }
 public static void CreateFloatingText(string text, Transform location,GameObject enemy)
 {
  //find if null
   //create an instance of the text prefab
   GameObject instance = Instantiate(ui2);
   
   //convert it's called location to screenspace
   Vector3 screenPos = Camera.main.WorldToScreenPoint(
   new Vector3(enemy.transform.position.x + Random.Range(min,max), enemy.transform.position.y, enemy.transform.position.z));
   //parent that instance to the canvas
   instance.transform.SetParent(parent, false);
   //set the instance's position to screenPos
   if(AiLich.dontCare == false) {
   instance.transform.position = screenPos;
   print(screenPos.x);
   print(screenPos.y);
   }
   //set the text to passed
   instance.GetComponentInChildren<Text>().text = text;

   //get anim clip length and destroy it at end of clip
   Animator anim = instance.GetComponentInChildren<Animator>();
   //grabs current animator clip and store it in array
   AnimatorClipInfo[] clipInfo = anim.GetCurrentAnimatorClipInfo(0);
   Destroy(instance, clipInfo[0].clip.length);
 }
}