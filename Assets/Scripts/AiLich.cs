 using UnityEngine;
 using System.Collections;
 
 public class AiLich : MonoBehaviour {
 
     public Transform[] patrolPoints;
     public float speed;

     Transform currentPatrolPoint;

     int currentPatrolIndex;

     public Transform target;
     public Animator animator;
     public float chaseRange;
     [SerializeField]
     public Rigidbody2D rb;
     public int health = 100;
    public GameObject lich;
    public float timer;
    [SerializeField]
    public string option;
     System.Random rand = new System.Random();
     private static FloatingText prefab;
     bool dummy = false;
     void Start () {
         currentPatrolIndex = 0;
         currentPatrolPoint = patrolPoints[currentPatrolIndex];
     }
     void Update() {
         float distanceToTarget = Vector3.Distance(transform.position, target.position);
         var sprite = GetComponent<SpriteRenderer>();
         if(dummy == false) {
             SwitchAnimation(option);
             dummy = true;
         }
        sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * -10f);
        if(distanceToTarget < 2) {
            Vector3 targetDir = target.position - transform.position;
             float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            SwitchAnimation("Lich Attack");
             Vector2 velocity = new Vector2((transform.position.x - target.position.x) * speed, (transform.position.y - target.position.y) * speed);
             rb.velocity = -velocity;
             animator.SetFloat ("X", -velocity.x);
             animator.SetFloat ("Y", -velocity.y); 
        }
         else if(distanceToTarget < chaseRange) {
             Vector3 targetDir = target.position - transform.position;
             float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            SwitchAnimation("Lich Walk");
             Vector2 velocity = new Vector2((transform.position.x - target.position.x) * speed, (transform.position.y - target.position.y) * speed);
             rb.velocity = -velocity;
             animator.SetFloat ("X", -velocity.x);
             animator.SetFloat ("Y", -velocity.y);
         }
         timer += Time.deltaTime;
         if(health <= 0) {
             gameObject.SetActive(false);
         }
        //  print(health);
        //  print("timer" + timer);
     }

     void OnMouseOver () {
 		//click object multiple times to turn on or off. 
 		//if mouse is being clicked else where, then noting should happen.
		 if(timer > 1.2f) {
 			if(Input.GetMouseButton(0)) {
                 if((transform.position.x - target.position.x) < 2 || (transform.position.x - target.position.x) > -2){
                  int damage = rand.Next(3, 5);
                 health -= damage;
                 string damageSTR = damage + "";
                 print(damageSTR);
                 timer = 1f;
                  Vector3 moveDirection = target.position - transform.position;
                   rb.AddForce( moveDirection.normalized * -700f);
                   PopupTextController.CreateFloatingText(damageSTR,transform);
                 }
                 else if((transform.position.y - target.position.y) < 2 || (transform.position.y - target.position.y) > 2) {
                 int damage = rand.Next(3, 10);
                 health -= damage;
                 string damageSTR = damage + "";
                 print(damageSTR);
                 timer = 1f;
            
                  Vector3 moveDirection = target.position - transform.position;
                   rb.AddForce( moveDirection.normalized * -700f);
                    PopupTextController.CreateFloatingText(damageSTR, transform);
                 }
            }
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