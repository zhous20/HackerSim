using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMovement : MonoBehaviour
{

  public float speed;
  private Rigidbody2D SErigidbody;
  private Vector3 change;
  private Animator animator;
  private string currState;


  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
    SErigidbody = GetComponent<Rigidbody2D>();

  }

  // Update is called once per frame
  void Update()
  {
    change = Vector3.zero;
    change.x = Input.GetAxisRaw("Horizontal");
    change.y = Input.GetAxisRaw("Vertical");
    UpdateAnimationAndMove();
  }

  void UpdateAnimationAndMove()
  {
    if(change != Vector3.zero)
    {
      MoveSE();
      animator.SetFloat("moveX", change.x);
      animator.SetFloat("moveY", change.y);
      animator.SetBool("moving", true);
    }
    else
    {
      animator.SetBool("moving", false);
    }
  }

  void MoveSE()
  {
    SErigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
  }
}
