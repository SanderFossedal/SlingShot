using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning2 : MonoBehaviour
{
    private float distance;
    private float distanceUsed;
    [SerializeField]
    private float ballSpawnRate = 3;
    [SerializeField]
    private string enemyToSpawn;
    // Update is called once per frame
    void Update()
    {
        if(distance < transform.position.x + 50)
        {
            distance = transform.position.x + 50;
        }
        float distToGo = Mathf.Floor(distance - distanceUsed);

        //distToGo > ___ er nummeret som bestemmer hvor ofte baller spawner
        if(distanceUsed < distance && distToGo > ballSpawnRate)
        {
            distanceUsed = distance;
            print(distToGo);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        //float yPos = Mathf.Floor(Mathf.Abs(Random.Range(0f, 1f) - Random.Range(0f, 1f)) * (1 + 100 - (-2) + (-2)));
        //100 er max høyde
        float yPos = Mathf.Floor(Mathf.Abs(Random.Range(0f, 1f) - Random.Range(0f, 1f)) * (1 + 100 - (-2)) + (-2));
        Vector2 posToSpawnEnemy = new Vector2(distance, yPos);

        Instantiate(Resources.Load(enemyToSpawn), posToSpawnEnemy, Quaternion.identity);
    }
}
