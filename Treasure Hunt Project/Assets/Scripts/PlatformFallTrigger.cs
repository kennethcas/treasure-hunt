using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallTrigger : MonoBehaviour
{
    BoxCollider2D boxCollider;
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
