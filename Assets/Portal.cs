using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject portal;
    public void InstantiatePortal()
    {
        var clone = Instantiate(portal, gameObject.transform.position, gameObject.transform.rotation);
    }
}
