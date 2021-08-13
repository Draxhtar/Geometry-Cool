using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject levelCompleteUI;
    [SerializeField] private GameObject winSound;

    public void CompleteLevel() 
    {
        levelCompleteUI.SetActive(true);
        Instantiate(winSound);
    }
}
