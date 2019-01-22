using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {

  public Rigidbody2D rb;

  public Animator animator;

  Vector3 movement;

  Vector3 mouseMovement;

  [SerializeField]

  private Stats stamina;

  public static float moveSpeed = 3f;

  [SerializeField]

  public float sensitivity = 0.5f;

  public GameObject canvas;

  float ButtonLasts = 0.5f; // Half a second before reset
  [SerializeField] public GameObject CharacterPanel;
  [SerializeField] public EquipmentSlot equipmentSlot;
  [SerializeField] public Item item;
  [SerializeField] public Collider2D collider2;

  [SerializeField] public Collider2D[] enemies;

  private bool isOpen;

  int ButtonCount = 0;

  public static bool move = true;
  void Start () {
    CharacterPanel.SetActive (false);
    mouseMovement = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x - 50,
      Input.mousePosition.y + 50, Camera.main.nearClipPlane));
      canvas.SetActive(false);
  }
  void Update () {
    Move ();

    GetInput ();
    if (Input.GetKeyDown (KeyCode.I)) {
      isOpen = !isOpen;
    }
    if (isOpen) {
      CharacterPanel.SetActive (true);
    } else {
      CharacterPanel.SetActive (false);
    }
    var sprite = GetComponent<SpriteRenderer> ();
    sprite.sortingOrder = Mathf.RoundToInt (transform.position.y * -10f);
  }
  // Update is called once per frame

  void Move () {
    Vector3 objPos = transform.position; //gets player position
    Vector3 mousePos = Input.mousePosition; //gets mouse postion
    mousePos = Camera.main.ScreenToWorldPoint (mousePos);
    float mousePosX = mousePos.x - objPos.x; //gets the distance between object and mouse position for x
    float mousePosY = mousePos.y - objPos.y; //gets the distance between object and mouse position for y  if you want this.
    animator.SetFloat ("HorizontalMouse", mousePosX);
    animator.SetFloat ("VerticalMouse", mousePosY);
    movement = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
    if(move) {
    rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * moveSpeed, Input.GetAxis ("Vertical") * moveSpeed);
    }
    if (Input.GetMouseButton (0) && (movement.x != 0 || movement.y != 0) && equipmentSlot.Item == item) {

      SwitchAnimation ("Attack Walk Layer");
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

      if (Physics.Raycast (ray, out hit)) {
        if (hit.transform.name == "forwardleft") {
          print ("My object is clicked by mouse");
        }
      }
    } else if (Input.GetMouseButton (0) && equipmentSlot.Item == item) {
      SwitchAnimation ("Attack Idle Layer");
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

      if (Physics.Raycast (ray, out hit)) {
        if (hit.transform.name == "forwardleft") {
          print ("My object is clicked by mouse");
        }

      }

    } else if (movement.x != 0 || movement.y != 0) {
      SwitchAnimation ("Walk Layer");
      animator.SetFloat ("Horizontal", movement.x);
      animator.SetFloat ("Vertical", movement.y);

    } else {

      SwitchAnimation ("Idle Layer");

    }

  }

  void GetInput () {
    if(Input.GetKeyDown(KeyCode.T)) {
      canvas.SetActive(!canvas.activeSelf);
    }
  }

  void SwitchAnimation (string layer) {

    for (int i = 0; i < animator.layerCount; i++)

    {

      animator.SetLayerWeight (i, 0);

    }

    animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);

  }

}