using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  Rigidbody rb;
  public float speed = 10.0F;
  float rotationSpeed = 50.0F;
  Animator animator;
  static public bool dead = false;

  void Start()
  {
    rb = this.GetComponent<Rigidbody>();
    animator = GetComponentInChildren<Animator>();
    animator.SetBool("Idling", true);
  }

  void FixedUpdate()
  {
    float translation = Input.GetAxis("Vertical") * speed;
    float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

    translation *= Time.deltaTime;
    rotation *= Time.deltaTime;

    Quaternion turn = Quaternion.Euler(0f, rotation, 0f);

    rb.MovePosition(rb.position + this.transform.forward * translation);
    rb.MoveRotation(rb.rotation * turn);

    animator.SetBool("Idling", translation == 0);

    if (dead)
    {
      animator.SetTrigger("isDead");
      this.enabled = false;
    }
  }
}
