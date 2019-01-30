using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingText : MonoBehaviour
{
    public Animator animator;
    public Text damage;
    
    void Start() {
          AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
          Destroy(gameObject, clipInfo[0].clip.length);
    }

    public void SetText(string text) {
        damage.text = text;
    }
}
