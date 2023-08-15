using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationScript : MonoBehaviour
{
    //First you need a Navigation surface from GameObject->Ai->Navigation surface
    //Hide the objects you don't want the surface to bake such as the player
    //Bake surface, take into consideration that for diferent agent types you need diferent navigation surfaces
    //In the enemy GameObject put the NavMeshComponent
    //Then create the NavigationScript
    //You can create different enemy types by changing or adding an Agent Type (go to Windows->AI->Navigation)
    //Also you can create a NavMesh Modifier Volume, which let you assign not walkable areas

    [SerializeField] Transform player;
    [SerializeField] NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        player = playerGameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }
}
