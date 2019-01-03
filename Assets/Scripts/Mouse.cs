using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

	// Use this for initialization
	 public Texture2D cursorTexture;
 void Start() {
	  Cursor.SetCursor(cursorTexture, new Vector2(5,0), CursorMode.Auto);
 }
}