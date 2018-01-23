using UnityEngine;
using UnityEngine.SceneManagement;

public class Failure : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            CheckpointManager.UpdateCheckpoint((new GameObject()).transform);
            Fail();
        }
    }

	public void Fail()
	{
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
	}
}
