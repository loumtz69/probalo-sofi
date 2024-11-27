using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eat : MonoBehaviour

{
    public GameObject powerBar;
    public GameObject eats;
    public playerMovement playerMovement;  
    public PowerUpController PowerUpController;
    public changeBall changeBall;
    public bool powerOfFire = false;
    public powerUpBar powerUpBar;
    public Renderer rendererPlayer;
    public Material materialFurby;
    public Material materialFireMonster;
    public Material materialIceWall;
    public Material materialAir;
    private bool _isFurby = true; 
    private float _timeChangeMaterial = 5f;
    public LayerMask layer;
    void Update()
    {


        if (powerUpBar.powerActually == powerUpBar.powerMax)
        {

            powerBar.SetActive(false);
            eats.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.E) && powerUpBar.powerActually == powerUpBar.powerMax)
        {

            
            EatEnemy(); 
        }
    }

    IEnumerator ChangeMaterialFire()
    {
        Material actualMaterial_Fire = rendererPlayer.material;

        rendererPlayer.material = _isFurby ? materialFireMonster : materialFurby;
        _isFurby = !_isFurby;

        yield return new WaitForSeconds(_timeChangeMaterial);
        powerOfFire = false;

        rendererPlayer.material = actualMaterial_Fire;


    }

    IEnumerator ChangeMaterialIce()
    {
        Material actualMaterial_Ice = rendererPlayer.material;

        rendererPlayer.material = _isFurby ? materialIceWall : materialFurby;
        _isFurby = !_isFurby;

        yield return new WaitForSeconds(_timeChangeMaterial);
        powerOfFire = false;

        rendererPlayer.material = actualMaterial_Ice;

    }

    IEnumerator ChangeMaterialAir()
    {
        Material actualMaterial_Air = rendererPlayer.material;

        rendererPlayer.material = _isFurby ? materialAir : materialFurby;
        _isFurby = !_isFurby;

        yield return new WaitForSeconds(_timeChangeMaterial);
        powerOfFire = false;

        rendererPlayer.material = actualMaterial_Air;

    }

    bool IsEnemyNear()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                return true;
            }
        }
        return false;
    }

    void EatEnemy()
    {
        eats.SetActive(false);

        int index = 0;
        float distance = Mathf.Infinity;


        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f, layer);

        if (hitColliders.Length == 0)   
            return;

        powerUpBar.powerActually = powerUpBar.powerMin;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            var x = Vector3.Distance(hitColliders[i].transform.position, transform.position);

            if (x < distance)
            {
                index = i; 
            }
        }
  
        if (hitColliders[index].gameObject.CompareTag("Enemy"))
        {            
            Destroy(hitColliders[index].gameObject);
            powerOfFire = true;

            StartCoroutine(ChangeMaterialFire());       
        }

        if (hitColliders[index].CompareTag("EnemyIce"))
        {
            Destroy(hitColliders[index].gameObject);
            powerOfFire = true;

            StartCoroutine(ChangeMaterialIce());
        }

        if (hitColliders[index].CompareTag("EnemyAir"))
        {
            Destroy(hitColliders[index].gameObject);
            powerOfFire = true;
            playerMovement.jumpForce = 100;
            StartCoroutine(ChangeMaterialAir());
        }

    }


}
