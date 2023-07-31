using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //[SerializeField] GameObject portal;
    /*public void InstantiatePortal()
    {
        var clone = Instantiate(portal, gameObject.transform.position, gameObject.transform.rotation);
    }*/

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ActivatePortal()
    {
        gameObject.SetActive(true);
    }
}
