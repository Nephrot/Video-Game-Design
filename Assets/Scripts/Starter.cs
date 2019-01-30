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
  // [SerializeField] public Collider2D collider2;
  [SerializeField] public Collider2D yoHere;

  [SerializeField] public Collider2D[] enemies;

  public static bool isOpen;
  [SerializeField] private Transform pfDashEffect;

  public GameObject audioSource;

  int ButtonCount = 0;
  [SerializeField]
  private Vector3 lastMoveDir;
  [SerializeField]
  public Stats health;
  public float healthValue = 100;
  private float maxHealth = 100;
  public static bool move = true;
  private float manaValue = 50;
  [SerializeField]
  private Stats mana;
  private float maxMana = 100;
  [SerializeField]
  private Stats staminabar;
  private float staminaValue = 100;
  private float maxStamina = 100;
  float time11;
  float time21;
  float time12;
  float time22;
  float time13;
  float time23;
  float time14;
  float time24;
  float thirdTimer = 0.5f;
  bool isTap1 = false;
  bool isTap2 = false;
  bool isTap3 = false;
  bool isTap4 = false;
  float timer;
  public float waitTime = 4f;

  public float dashCooldown;
  public bool canIDash = true;
  public Vector2 CurrentVel;
  public GameObject dashPrefab;
  public bool dash = false;
  public float timer5;

  public static bool terminal = false;
  public GameObject journal;
  void Start () {
    health.createStat (100, 100);
    mana.createStat (100, 100);
    staminabar.createStat (100, 100);

    CharacterPanel.SetActive (false);
    mouseMovement = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x - 50,
      Input.mousePosition.y + 50, Camera.main.nearClipPlane));
    canvas.SetActive (false);
    journal.SetActive(false);

  }
  void Update () {
    Move ();
    GetInput ();
    audioSource.transform.position = transform.position;
    if (!terminal) {
      if (Input.GetKeyDown (KeyCode.I)) {
        isOpen = !isOpen;
      } else if (terminal) {
        isOpen = false;
        CharacterPanel.SetActive (false);
      }
      if (isOpen) {
        CharacterPanel.SetActive (true);
      } else {
        CharacterPanel.SetActive (false);
      }
    }
    if(!terminal && Input.GetKeyDown(KeyCode.J)) {
      journal.SetActive(!journal.activeSelf);
    }
    var sprite = GetComponent<SpriteRenderer> ();
    sprite.sortingOrder = Mathf.RoundToInt (transform.position.y * -10f);
    regen ();
    HandleDash ();
  }
  // Update is called once per frame

  void Move () {
    Vector3 objPos = transform.position; //gets player position
    Vector3 mousePos = Input.mousePosition; //gets mouse postion
    mousePos = Camera.main.ScreenToWorldPoint (mousePos);
    float mousePosX = mousePos.x - objPos.x; //gets the distance between object and mouse position for x
    float mousePosY = mousePos.y - objPos.y; //gets the distance between object and mouse position for y  if you want this.
    if (!terminal) {
      animator.SetFloat ("HorizontalMouse", mousePosX);
      animator.SetFloat ("VerticalMouse", mousePosY);
    }
    movement = new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
    if (move && !terminal) {
      rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * moveSpeed, Input.GetAxis ("Vertical") * moveSpeed);
    }
    if (Input.GetMouseButton (0) && (movement.x != 0 || movement.y != 0) && equipmentSlot.Item == item && !terminal) {

      SwitchAnimation ("Attack Walk Layer");
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

      if (Physics.Raycast (ray, out hit)) {
        if (hit.transform.name == "forwardleft") {
          print ("My object is clicked by mouse");
        }
      }
    } else if (Input.GetMouseButton (0) && equipmentSlot.Item == item && !terminal) {
      SwitchAnimation ("Attack Idle Layer");
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

      if (Physics.Raycast (ray, out hit)) {
        if (hit.transform.name == "forwardleft") {
          print ("My object is clicked by mouse");
        }

      }

    } else if ((movement.x != 0 || movement.y != 0) && !terminal) {
      SwitchAnimation ("Walk Layer");
      animator.SetFloat ("Horizontal", movement.x);
      animator.SetFloat ("Vertical", movement.y);

    } else if (!terminal) {

      SwitchAnimation ("Idle Layer");

    }

  }

  void GetInput () {
    if (Input.GetKeyDown (KeyCode.T) && !terminal) {
      canvas.SetActive (!canvas.activeSelf);
      terminal = true;
      rb.velocity = new Vector2 (0, 0);
      SwitchAnimation ("Idle Layer");
    }
    if (Input.GetKeyDown (KeyCode.Escape) && terminal) {
      canvas.SetActive (!canvas.activeSelf);
      terminal = false;
    }
  }

  void SwitchAnimation (string layer) {

    for (int i = 0; i < animator.layerCount; i++) {
      animator.SetLayerWeight (i, 0);
    }
    animator.SetLayerWeight (animator.GetLayerIndex (layer), 1);
  }
  void regen () {
    timer += Time.deltaTime;
    if (timer > waitTime) {
      timer = 0f;
      health.CurrentValue += 10;
      mana.CurrentValue += 10;
      staminabar.CurrentValue += 10;
    }
  }
  private void HandleDash () {
    if (Input.GetKeyDown (KeyCode.Space) && !terminal) {
      float dashDistance = 30f;
      Vector3 beforeDashPosition = transform.position;
      if (TryMove (lastMoveDir, dashDistance) && (movement.x != 0 || movement.y != 0) && staminabar.CurrentValue > 20) {
        staminabar.CurrentValue -= 20;
        Transform dashEffectTransform = Instantiate (pfDashEffect, beforeDashPosition, Quaternion.identity);
        dashEffectTransform.eulerAngles = new Vector3 (0, 0, GetAngleFromVectorFloat (movement));
        rb.velocity = dashEffectTransform.eulerAngles;
        float dashEffectWidth = 30f;
        dashEffectTransform.localScale = new Vector3 (5f, 5f, 5f);
        dash = true;
      }
    }
    if (dash == true) {
      transform.position += movement * 0.1f;
      timer5 += Time.deltaTime;

    }
    if (timer5 >.3) {
      dash = false;
      timer5 = 0;
    }
  }
  public static float GetAngleFromVectorFloat (Vector3 dir) {
    dir = dir.normalized;
    float n = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
    if (n < 0) n += 360;

    return n;
  }
  private bool CanMove (Vector3 dir, float distance) {
    return Physics2D.Raycast (transform.position, dir, distance).collider == null;
  }
  private bool TryMove (Vector3 baseMoveDir, float distance) {
    Vector3 moveDir = baseMoveDir;
    bool canMove = CanMove (moveDir, distance);
    if (!canMove) {
      // Cannot move diagonally
      moveDir = new Vector3 (baseMoveDir.x, 0f).normalized;
      canMove = moveDir.x != 0f && CanMove (moveDir, distance);
      if (!canMove) {
        // Cannot move horizontally
        moveDir = new Vector3 (0f, baseMoveDir.y).normalized;
        canMove = moveDir.y != 0f && CanMove (moveDir, distance);
      }
    }

    if (canMove) {
      lastMoveDir = moveDir;
      transform.position += moveDir * distance;
      return true;
    } else {
      return false;
    }
  }
  void OnCollisionEnter (Collision col) {
    if (col == yoHere) {
      dash = false;
    }
  }
}