using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    //Receive update from subject (e.g PickupItemEventmanager)
    void UpdateFromSubject(ISubject subject);
}
