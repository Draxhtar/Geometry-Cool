using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEndTrigger : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Win"))
            gameManager.CompleteLevel();
    }
}
