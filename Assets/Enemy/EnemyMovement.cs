using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] CapsuleCollider col;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float rotationSpeed = 1.0f;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate direction from enemy to player
        Vector3 direction = player.transform.position - transform.position;

        //Calculate needed target rotation to look at player
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        //Smoothly rotate
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Calculate the distance between current position to the target position
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Calculate the new position moving towards the target position at a specified speed
        Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);

        //Move towards the player, until the distance between them reaches a certain value.
        if (distance > col.bounds.extents.magnitude + 0.1f)
        {
            transform.position = newPosition;
        }
    }
}
