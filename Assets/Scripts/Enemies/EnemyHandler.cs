using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public static event Action onDeath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(Resources.Load("EnemyDeath"), transform.position, Quaternion.identity);
        onDeath?.Invoke();
    }
}
