using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private int maxEnemyCount = 10;
    [SerializeField] private float margin;
    private int counter;
    void Start()
    {
        //Invoke("SpawnRandom", 1);
        spawnCount(maxEnemyCount);
    }

    private void OnEnable()
    {
        //EnemyHandler.onDeath += SpawnRandom;
        EnemyHandler.onDeath += spawn;

    }

    private void OnDisable()
    {
        //EnemyHandler.onDeath -= SpawnRandom;
        EnemyHandler.onDeath -= spawn;
    }

    private void Update()
    {
        //while(counter < maxEnemyCount)
        //{
        //    SpawnRandom();
        //    counter++;
        //}
    }


    //Old
    void spawn()
    {
        int spawnPointX = Random.Range(-16, 17);
        int spawnPointY = Random.Range(-7, 8);
        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, 0);

        Instantiate(Resources.Load("Enemy"), spawnPosition, Quaternion.identity);
    }

    public void SpawnRandom()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height)
        , Camera.main.farClipPlane / 2));
        Instantiate(Resources.Load("Enemy"), screenPosition, Quaternion.identity);
        
    }

    private void spawnCount(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //SpawnRandom();
            spawn();
        }
    }
}
