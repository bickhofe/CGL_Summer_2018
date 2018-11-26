using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    // Commands are called on the Client, but executed on the Server!
    // ClientRpc's are called on the Server, but executed on the Client!

    private NetworkStartPosition[] spawnPoints;

    public bool destroyOnDeath;

    public const int maxHealth = 100;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public Text healthDisplay;

    void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {

            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                //currentHealth = 0;
                currentHealth = maxHealth;

                RpcRespawn();
                //Debug.Log("Dead!");
            }


        }

        healthDisplay.text = "Life: "+ currentHealth;
    }

    void OnChangeHealth(int currentHealth)
    {
        healthDisplay.text = "Life: " + currentHealth;
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            //transform.position = Vector3.zero;
            //transform.rotation = Quaternion.identity;

            // Set the spawn point to origin as a default value
            Vector3 spawnPoint = Vector3.zero;

            // If there is a spawn point array and the array is not empty, pick one at random
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            transform.position = spawnPoint;
        }
    }
}
