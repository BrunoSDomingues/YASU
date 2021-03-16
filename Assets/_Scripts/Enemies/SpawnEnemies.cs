using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    // Spawn on timer: https://answers.unity.com/questions/399385/how-do-i-spawn-enemies-based-on-a-timer.html
    // https://answers.unity.com/questions/772331/spawn-object-in-front-of-player-and-the-way-he-is.html

    public GameObject enemyShip, asteroid;
    GameManager gm;
    private float timer;
    private int nEnemies;

    void Start()
    {
        gm = GameManager.GetInstance();
        timer = Time.time;
        nEnemies = 0;
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        nEnemies = GameObject.FindGameObjectsWithTag("asteroid").Length + GameObject.FindGameObjectsWithTag("enemies").Length;

        GameObject player = GameObject.FindWithTag("player");

        if (player)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.y = Random.Range(-4.0f, 4.0f);
            Vector3 playerDir = player.transform.right;
            Quaternion playerRot = player.transform.rotation;

            float spawnDistance = 20;

            Vector3 spawnPos = playerPos + spawnDistance * playerDir;

            if (timer < Time.time && nEnemies <= 10)
            {
                float randomValue = Random.Range(0.0f, 1.0f);

                if (randomValue > 0.6)
                {
                    Instantiate(asteroid, spawnPos, playerRot);
                    timer = Time.time + 2;
                }
                else
                {
                    Instantiate(enemyShip, spawnPos, playerRot);
                    timer = Time.time + 1;
                }
            }
        }
    }
}
