using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int score { get; set; }


    private void Start()
    {
        score = 0;
    }
    private void OnEnable()
    {
        EnemyHandler.onDeath += increaseScore;
    }

    private void OnDisable()
    {
        EnemyHandler.onDeath -= increaseScore;
    }



    private void increaseScore()
    {
        score++;
        Debug.Log(score);
    }
}
