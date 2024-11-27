using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pastilla : MonoBehaviour
{

    public PowerUpController powerUpController;
    public GameObject powerBall;
    public GameObject candy;
    public bool grajea = false;
    public bool activate = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("grajea"))
        {
            
            

            if (activate == false)
            {
                powerBall.SetActive(true);
                candy.SetActive(false);
                grajea = true;
                Destroy(other.gameObject);
                Invoke(nameof(DesactivarGrajea), 5f);
                activate = true;
            }

            else
            {
                grajea = true;
                Destroy(other.gameObject);
                Invoke(nameof(DesactivarGrajea), 5f);
            }


        }
    }

    private void DesactivarGrajea()
    {
        grajea = false;
    }
}
