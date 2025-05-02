using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class sceneTracker
{
    public static string PreviousSceneName = null;

	public static void SetPreviousScene(string sceneName)
	{
		PreviousSceneName = sceneName;
	}

	public static string GetPreviousScene()
	{
		return PreviousSceneName;
	}
}
