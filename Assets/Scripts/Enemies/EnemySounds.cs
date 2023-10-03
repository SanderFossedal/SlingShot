using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]private List<AudioClip> sounds = new List<AudioClip>();


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        EnemyHandler.onDeath += playSound;
    }

    private void OnDisable()
    {
        EnemyHandler.onDeath -= playSound;
    }


    private void playSound()
    {
        int tall = Random.Range(0, 4);
        audioSource.PlayOneShot(sounds[tall]);
        Debug.Log("Playing sound!");
    }
}
