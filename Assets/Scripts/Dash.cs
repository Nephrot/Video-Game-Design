// using UnityEngine;
// using System.Collections;
 
// public class Dash : EntityComponent
// {
//     public LayerMask ObstacleLayer;
 
//     public Vector2 Velocity
//     {
//         get;
//         protected set;
//     }
//     public Vector2 MovementDirection
//     {
//         get;
//         protected set;
//     }
//     public Rigidbody2D RBody2D
//     {
//         get;
//         protected set;
//     }
//     public bool IsMoving
//     {
//         get
//         {
//             return Velocity.sqrMagnitude > 0.01f;
//         }
//     }
 
//     public bool IsDashing
//     {
//         get;
//         protected set;
//     }
//     protected Vector3 dashTarget;
//     protected float dashSpeed;
 
//     public override void Initialize()
//     {
//         base.Initialize();
 
//         RBody2D = GetComponent<Rigidbody2D>();
//         ObstacleLayer = LayerMask.GetMask("Obstacles");
//     }
 
//     protected virtual void Update()
//     {
//         Velocity = MovementDirection * owner.Statistics.GetStatValue(StatType.MoveSpeed);
//     }
//     protected virtual void FixedUpdate()
//     {
//         if (IsDashing)
//         {
//             Velocity = Vector2.zero;
//             RBody2D.velocity = Vector2.zero;
 
//             float distSqr = (dashTarget - transform.position).sqrMagnitude;
//             if (distSqr < 0.1f)
//             {
//                 OnDashFinished();
//                 IsDashing = false;
//                 dashTarget = Vector2.zero;
//                 owner.Vitals.IsInvincible = false;
//             }
//             else
//             {
//                 owner.Movement.RBody2D.MovePosition(Vector3.Lerp(transform.position,
//                     dashTarget, dashSpeed * Time.deltaTime));
//             }
//         }
//         else
//         {
//             RBody2D.AddForce(Velocity);
//         }
//     }
 
//     public virtual void ClearVelocity()
//     {
//         Velocity = Vector2.zero;
//         RBody2D.velocity = Vector2.zero;
//     }
 
//     public void Dash(float dashDistance, float speed, Vector2 direction)
//     {
//         IsDashing = true;
 
//         RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, dashDistance, ObstacleLayer);
 
//         if (hit)
//         {
//             dashTarget = transform.position + (Vector3)((direction * dashDistance)
//                 * hit.fraction);
//         }
//         else
//         {
//             dashTarget = transform.position + (Vector3)(direction * dashDistance);
//         }
 
//         dashSpeed = speed;
//         owner.Movement.ClearVelocity();
//     }
 
//     protected virtual void OnDashFinished()
//     {
 
//     }
// }
