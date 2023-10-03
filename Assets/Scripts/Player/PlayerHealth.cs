using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public float maxHealth;
    public float currentHealth;
    [SerializeField] private float healthDrain = 10;

    public static event Action onDeath;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            die();
            //Debug.Log("Player Dead");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            drainHealth();
        }
    }

    private void OnEnable()
    {
        EnemyHandler.onDeath += heal;
    }

    private void OnDisable()
    {
        EnemyHandler.onDeath -= heal;
    }

    private void die()
    {
        gameObject.SetActive(false);
        Instantiate(Resources.Load("PlayerDeath"), transform.position, Quaternion.identity);
        onDeath?.Invoke();
    }

    private void drainHealth()
    {
        currentHealth -= healthDrain/60;
    }

    private void heal()
    {
        currentHealth += 10;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Lava")
        {
            die();
        }
    }
}
