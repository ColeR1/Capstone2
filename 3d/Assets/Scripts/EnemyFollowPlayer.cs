using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{

    public float detectionRange = 10f;
    public float moveSpeed = 3f;
    private Transform player;
    private bool isChasing = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Assuming player is tagged as "Player".
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Enemy can see the player within detection range.
            isChasing = true;
        }
        else
        {
            // Player is out of range.
            isChasing = false;
        }

        if (isChasing)
        {
            // Move towards the player.
            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

     private void OnDrawGizmos()
    {
        // Draw a wire sphere to represent the detection range in the Scene view.
        Gizmos.color = Color.red; // You can change the color to your liking.
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
