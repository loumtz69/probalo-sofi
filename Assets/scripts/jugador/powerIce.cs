using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerIce : MonoBehaviour
{
    public powerUpBar powerUpBar; 
    public string water = "agua"; 
    public eat eat;
    public Material iceWallMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "agua")
        {
            if (eat.powerOfFire == true)
            {
                Collider aguaCollider = other.gameObject.GetComponent<Collider>();

                aguaCollider.isTrigger = false;

                other.gameObject.GetComponent<MeshRenderer>().material = iceWallMaterial;


            }
        }
    }

}
