using UnityEngine;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{
    public Fade fade;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            // Automatically deletes itself because scene is reinitialized
            CheckpointManager.UpdateCheckpoint((new GameObject()).transform);
            FailImmediate();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void FailImmediate()
    {
        Reload();
    }

	public void Fail()
	{
        fade.fadeSpeed = .15f;
        fade.FadeOut(Reload);
	}

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
