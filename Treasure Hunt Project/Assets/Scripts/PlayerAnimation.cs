using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public AudioSource bleepSource;

    private void Start()
    {
        bleepSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       // if (other.CompareTag("Player"))
        
            bleepSource.Play();
        
        
    }
}
