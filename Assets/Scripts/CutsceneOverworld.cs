using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneOverworld : MonoBehaviour
{
    public static bool stopTimer = true;
    float timer = 0.0f;
    
    public GameObject sword;
    public GameObject helmet;

    public Animator chestAnimator;
    public static GameObject CharacterPanelHeld = null;

    public GameObject CharacterPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        AiLich.switchCharacter = true;
        stopTimer = true;
        AiLich.dontCare = true;
          FollowPlayer.preferredPlayer = CutsceneTutorial.personHeld;
        CutsceneTutorial.personHeld.transform.position = new Vector2 (-15, -11);
         
        
    }

    // Update is called once per frame
    void Update()
    {
          AiLich.switchCharacter = true;
          AiLich.dontCare = true;
        if(!stopTimer) {
          timer += Time.deltaTime;
          SwitchAnimation("Open");
        }
        if(timer > 1) {
          helmet.SetActive(false);
          sword.SetActive(false);
        }
    

    }
    void SwitchAnimation (string layer) {
 		for (int i = 0; i < chestAnimator.layerCount; i++) {
 			chestAnimator.SetLayerWeight (i, 0);
 		}

 		chestAnimator.SetLayerWeight (chestAnimator.GetLayerIndex (layer), 1);
 	}
}
