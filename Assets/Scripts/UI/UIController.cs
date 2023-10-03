using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerHealth.onDeath += enableGameOver;
    }
    private void OnDisable()
    {
        PlayerHealth.onDeath -= enableGameOver;
    }

    private void enableGameOver()
    {
        gameOverUI.SetActive(true);
    }
}
