using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
    public void gameStart(string levelOne)
    {
        SceneLoader.LoadScene("levelOne");
        Debug.Log("Cambio de escena");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Se sale");
    }

    public void Restart()
    {
        SceneLoader.LoadScene("levelOne");
        Debug.Log("Cambio de escena");
    }
}
