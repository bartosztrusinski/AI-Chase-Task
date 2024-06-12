using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCheckpoints : MonoBehaviour
{

  Transform goal;
  float speed = 5.0f;
  float accuracy = 5.0f;
  float rotSpeed = 2.0f;
  GameObject[] checkpoints;
  GameObject currentNode;
  int currentCheckpoint = 0;
  Graph graph;

  public GameObject checkpointManager;

  void Start()
  {
    Time.timeScale = 5.0f;
    checkpoints = checkpointManager.GetComponent<CheckpointManager>().checkpoints;
    graph = checkpointManager.GetComponent<CheckpointManager>().graph;
    currentNode = checkpoints[0];
  }

  public void GoToHelipad()
  {
    graph.AStar(currentNode, checkpoints[2]);
    currentCheckpoint = 0;
  }

  public void GoToRuins()
  {
    graph.AStar(currentNode, checkpoints[7]);
    currentCheckpoint = 0;
  }

  public void GoToRocks()
  {
    graph.AStar(currentNode, checkpoints[5]);
    currentCheckpoint = 0;
  }

  public void GoToOilStorage()
  {
    graph.AStar(currentNode, checkpoints[4]);
    currentCheckpoint = 0;
  }

  public void GoToBuildings()
  {
    graph.AStar(currentNode, checkpoints[6]);
    currentCheckpoint = 0;
  }

  void LateUpdate()
  {
    if (graph.pathList.Count == 0 || currentCheckpoint == graph.pathList.Count) return;

    currentNode = graph.getPathPoint(currentCheckpoint);

    if (Vector3.Distance(
      graph.pathList[currentCheckpoint].getID().transform.position,
      transform.position) < accuracy)
    {
      currentCheckpoint++;
    }

    if (currentCheckpoint >= graph.pathList.Count) return;

    goal = graph.pathList[currentCheckpoint].getID().transform;

    Vector3 lookAtGoal = new Vector3(
        goal.position.x,
        transform.position.y,
        goal.position.z);

    Vector3 direction = lookAtGoal - this.transform.position;

    transform.rotation = Quaternion.Slerp(
        this.transform.rotation,
        Quaternion.LookRotation(direction),
        Time.deltaTime * rotSpeed);

    transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
  }
}
