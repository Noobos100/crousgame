using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float detectionRadius = 5.0f; // Detection radius

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            // Move towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.position += directionToPlayer * Time.deltaTime;
        }
        else
        {
            // Walk back and forth of 5 units
            transform.position += Vector3.right * 2;
            if (transform.position.x > 5)
            {
                transform.position = new Vector3(5, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -5)
            {
                transform.position = new Vector3(-5, transform.position.y, transform.position.z);
            }
        }
    }
}
