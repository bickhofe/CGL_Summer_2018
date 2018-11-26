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
        if (isLocalPlayer) spawnPoints = FindObjectsOfType<NetworkStartPosition>();
    }

    public void TakeDamage(int amount)
    {
        if (!isServer) return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            if (destroyOnDeath) Destroy(gameObject);
            else
            {
                currentHealth = maxHealth;
                RpcRespawn();
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

            Vector3 spawnPoint = Vector3.zero;
            if (spawnPoints != null && spawnPoints.Length > 0) spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            transform.position = spawnPoint;
        }
    }
}
