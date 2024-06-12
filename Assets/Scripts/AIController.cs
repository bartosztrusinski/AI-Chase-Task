using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
  public NavMeshAgent agent;
  public GameObject target;
  Animator anim;

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    agent.SetDestination(target.transform.position);
    anim.SetBool("isMoving", agent.remainingDistance >= 2.0f);
  }
}
