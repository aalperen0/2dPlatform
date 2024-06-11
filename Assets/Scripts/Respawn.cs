using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject player;
    public Transform startPoint;

    private PlayerHealth playerHealth;
    private Vector2 checkpoint;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        checkpoint = player.transform.position; // Setting initial checkpoint to start point
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // If a checkpoint has been achieved, use it. Otherwise, use the start point
            if (playerHealth.CheckPoint != null && playerHealth.CheckPoint != Vector2.zero)
            {
                player.transform.position = playerHealth.CheckPoint;
            }
            else
            {
                player.transform.position = startPoint.position;
            }
        }
    }



    /*
    public GameObject player;
    public Transform respawnPoint;
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.position;
        }
    }*/
}
