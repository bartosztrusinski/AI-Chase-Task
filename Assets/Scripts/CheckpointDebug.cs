using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CheckpointDebug : MonoBehaviour
{
  void RenameCheckpoints(GameObject overlook)
  {
    GameObject[] gameObjects;
    int i = 1;

    gameObjects = GameObject.FindGameObjectsWithTag("checkpoint");

    foreach (GameObject gameObject in gameObjects)
    {
      if (gameObject != overlook)
      {
        gameObject.name = "Checkpoint" + string.Format("{0:000}", i);
        i++;
      }
    }
  }

  void OnDestroy()
  {
    RenameCheckpoints(this.gameObject);
  }

  void Start()
  {
    if (this.transform.parent.gameObject.name != "Checkpoint") return;
    RenameCheckpoints(null);
  }

  void Update()
  {
    this.GetComponent<TextMesh>().text = this.transform.parent.gameObject.name;
  }
}
