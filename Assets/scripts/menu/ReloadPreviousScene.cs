using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadPreviousScene : MonoBehaviour
{
	public void ReloadPrevious()
	{
		string previousScene = sceneTracker.GetPreviousScene();
		if (!string.IsNullOrEmpty(previousScene))
		{
			SceneLoader.LoadScene(previousScene);
		}
		else
		{
			Debug.LogWarning("No hay una escena anterior registrada.");
		}
	}
}
