using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{

    public float spawnRate = 2f;
    float timer;
    public GameObject enemyObject;
    public GameManagerScript gmScript;

    void Start() {
        timer = spawnRate;
    }
    void Update()
    {
        if (gmScript.gameIsEnabled) {
            
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else {
                timer = spawnRate;
                EnemySpawn();
            }
            
        }
    }

    void EnemySpawn() {
        int spawnArea = Random.Range(1,5);

        float xRandomValue;
        float yRandomValue;

        switch (spawnArea)
        {
            case 1:
                xRandomValue = Random.Range(-10, 10);
                yRandomValue = 6f;
                Spawn(xRandomValue, yRandomValue);
                break;
            case 2:
                xRandomValue = -10f;
                yRandomValue = Random.Range(-5.5f, 5.5f);
                Spawn(xRandomValue, yRandomValue);
                break;
            case 3:
                xRandomValue = Random.Range(-10, 10);
                yRandomValue = -6f;
                Spawn(xRandomValue, yRandomValue);
                break;
            case 4:
                xRandomValue = 10f;
                yRandomValue = Random.Range(-5.5f, 5.5f);
                Spawn(xRandomValue, yRandomValue);
                break;
        }
    }

    void Spawn(float positionX, float positionY) {
        Instantiate(enemyObject, new Vector3(positionX, positionY, 0f), Quaternion.identity);
    }
}
