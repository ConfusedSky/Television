using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCheckpoint : MonoBehaviour 
{
    // Use this for initialization
    void Start()
    {
        CheckpointManager.MoveToCheckpoint(gameObject);
    }
}
