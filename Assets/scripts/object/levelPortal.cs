using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelPortal : MonoBehaviour
{
	public string triggerTag = "Player";
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(triggerTag))
		{
			int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
			int nextSceneIndex = currentSceneIndex + 1;

			if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
			{
				string currentSceneName = SceneManager.GetActiveScene().name;
				sceneTracker.SetPreviousScene(currentSceneName); 
				SceneManager.LoadScene(nextSceneIndex);
			}
			else
			{
				Debug.LogWarning("No hay una siguiente escena en Build Settings.");
			}
		}
	}
}

