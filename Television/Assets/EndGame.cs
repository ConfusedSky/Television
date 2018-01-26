using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {
    public Fade fade;

    void OnTriggerEnter()
    {
        fade.fadeSpeed = .15f;
        fade.FadeOut(End);
    }

    void End()
    {
        // Automatically deletes itself because scene is deleted
        CheckpointManager.UpdateCheckpoint((new GameObject()).transform);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
