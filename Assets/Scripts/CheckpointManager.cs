using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
  public enum direction
  {
    UNI,
    BI
  }

  public GameObject node1, node2;
  public direction dir;
}

public class CheckpointManager : MonoBehaviour
{
  public GameObject[] checkpoints;
  public Link[] links;
  public Graph graph = new Graph();

  void Start()
  {
    if (checkpoints.Length <= 0) return;

    foreach (GameObject checkpoint in checkpoints)
    {
      graph.AddNode(checkpoint);

      foreach (Link link in links)
      {
        graph.AddEdge(link.node1, link.node2);

        if (link.dir == Link.direction.BI)
        {
          graph.AddEdge(link.node2, link.node1);
        }
      }
    }
  }
}
