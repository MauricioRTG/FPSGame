using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public interface ISubject
{
    //Add observer
    void Subscribe(IObserver observer);

    //Remove observer
    void Unsubscribe(IObserver observer);

    //Notify all observers or subscribers of an event
    void NotifySubscribers();
}
