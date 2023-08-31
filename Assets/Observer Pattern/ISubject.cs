using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public interface ISubject
{
    //Add observer
    void Subscribe(GameObject observer);

    //Remove observer
    void Unsubscribe(GameObject observer);

    //Notify all observers or subscribers of an event
    void NotifySubscribers(pickupItemType pickupItemType);
}
