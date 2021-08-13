//Can be used to destroy any object after instantiating and certain amount of duration 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyParticle : MonoBehaviour
{
    [SerializeField] private float duration;

    private void OnEnable()
    {
        Invoke("DestroySelf", duration);
    }

    void DestroySelf() 
    {
        Destroy(gameObject);
    }
}
