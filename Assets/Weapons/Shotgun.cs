using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] Camera playerCamara;
    [SerializeField] Transform firePoint;
    [SerializeField] int pellets = 8;
    [SerializeField] float spreadAngle = 20.0f;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LineRenderer[] lineRenderers;  
    [SerializeField] WeaponAmmunition weaponAmmunition;
    [SerializeField] float trailDuration = 0.1f;
    [SerializeField] Transform shotgunTrailsTransform;


    void Start()
    {
        weaponAmmunition = FindObjectOfType<WeaponAmmunition>();
        playerCamara = FindObjectOfType<Camera>();
        Random.InitState(Time.frameCount);
        //GetLineRenderersFromParentTransform();
    }

    public override void InstantiateBullets()
    {

        for ( int i = 0; i < pellets; i++)
        {
            //Enable line renderers
            lineRenderers[i].enabled = true;

            //For this to work the line renderer has to have its Allignment to TransformZ and Use World space enable
            //Spread of shotgun pellets
            Vector3 spreadDirection = Quaternion.Euler(0, Random.Range(-spreadAngle, spreadAngle), 0) * firePoint.transform.forward;

            
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, spreadDirection, out hit, Mathf.Infinity, targetLayer)) 
            {
                //Update line renderer to show the trayectory conformed by two conected points in local space
                lineRenderers[i].positionCount = 2;
                //Set the first position of the line renderer to the fire point
                lineRenderers[i].SetPosition(0, firePoint.position);
                //Set the second position of the line renderer to the hit point
                lineRenderers[i].SetPosition(1 , hit.point);
                //Apply damage and effects to the target
                Debug.Log("Hit: " + hit.collider.gameObject.name);

            }
            else
            {
                //If there is not a hit, show maximum range with origin in the firePoint
                lineRenderers[i].positionCount = 2;
                lineRenderers[i].SetPosition(0, firePoint.position);
                lineRenderers[i].SetPosition(1, spreadDirection * 100f);

            }

            //Decrease ammunition according to the number of pellets fired
            weaponAmmunition.ammunitionAmount--;
        }
        //Disable line renderer after short delay
        Invoke("DisableTrail", trailDuration);
    }

    private void DisableTrail()
    {
        foreach(LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.enabled = false;
        }
        //lineRenderer.enabled = false;
    }

    private void GetLineRenderersFromParentTransform()
    {

        int childCount = shotgunTrailsTransform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            lineRenderers[i] = shotgunTrailsTransform.GetChild(i).GetComponent<LineRenderer>();
        }

    }
}
