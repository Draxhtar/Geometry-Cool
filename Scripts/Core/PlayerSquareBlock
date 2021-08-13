using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerSquareBlock : MonoBehaviour
{
   
    [SerializeField] float distance = 4f;
    [SerializeField] float spawnMoveTime = 0.1f;
    [SerializeField] float squareFinalSize = 0.9f;
   
    struct MaxAndLocation 
    {
        public float s_max;
        public float s_location;

        public MaxAndLocation(float max, float location) 
        {
            this.s_max = max;
            this.s_location = location;
        }
    }

    public void GoUp()
    {
        Vector3 positionToGo;
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, transform.up, distance, 1 << LayerMask.NameToLayer("Player"));
        if (hits.Length == 0) 
        {
            positionToGo = new Vector3(0, 1);
        }
        else { 
            float[] height = new float[hits.Length];
            for (int i = 0; i < height.Length; i++) 
            {
                height[i] = hits[i].transform.position.y;
            }
            MaxAndLocation _maxAndLocation = GetMax(height);
            positionToGo = new Vector3(0, (_maxAndLocation.s_max - transform.position.y) + 1);
        }
        transform.DOLocalMove(positionToGo, spawnMoveTime);
        transform.DOScale(squareFinalSize, spawnMoveTime);
    }

    public void GoDown()
    {
        Vector3 positionToGo;
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, new Vector3(0, -1, 0), distance, 1 << LayerMask.NameToLayer("Player"));
        if (hits.Length == 0)
        {
            positionToGo = new Vector3(0, -1);
        }
        else
        {
            float[] height = new float[hits.Length];
            for (int i = 0; i < height.Length; i++)
            {
                height[i] = hits[i].transform.localPosition.y;
            }
            MaxAndLocation _maxAndLocation = GetMin(height);
            positionToGo = new Vector3(0, _maxAndLocation.s_max - 1);
        }
        transform.DOLocalMove(positionToGo, spawnMoveTime);
        transform.DOScale(squareFinalSize, spawnMoveTime);
    }

    public void GoRight()
    {
        Vector3 positionToGo;
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, transform.right, distance, 1 << LayerMask.NameToLayer("Player"));
        if (hits.Length == 0)
        {
            positionToGo = new Vector3(1, 0);
        }
        else
        {
            float[] height = new float[hits.Length];
            for (int i = 0; i < height.Length; i++)
            {
                height[i] = hits[i].transform.localPosition.x;
            }
            MaxAndLocation _maxAndLocation = GetMax(height);
            positionToGo = new Vector3(_maxAndLocation.s_max + 1, 0);
        }
        transform.DOLocalMove(positionToGo, spawnMoveTime);
        transform.DOScale(squareFinalSize, spawnMoveTime);
    }

    public void GoLeft()
    {
        Vector3 positionToGo;
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, new Vector3(-1, 0, 0), distance, 1 << LayerMask.NameToLayer("Player"));
        if (hits.Length == 0)
        {
            positionToGo = new Vector3(-1, 0);
        }
        else
        {
            float[] height = new float[hits.Length];
            for (int i = 0; i < height.Length; i++)
            {
                height[i] = hits[i].transform.localPosition.x;
            }
            MaxAndLocation _maxAndLocation = GetMin(height);
            positionToGo = new Vector3(_maxAndLocation.s_max - 1, 0);
        }
        transform.DOLocalMove(positionToGo, spawnMoveTime);
        transform.DOScale(squareFinalSize, spawnMoveTime);
    }

    public void RayClockwise() 
    {
        
    }

    public void RayAntiClockwise() 
    {

    }

    MaxAndLocation GetMax(float[] floatArray)
    {
         float max = floatArray[0];
         float location = 0f;
         for (int i = 0; i < floatArray.Length; i++) {
             if (floatArray[i] > max) {
                 max = floatArray[i];
                 location = i;
             }
         }
        MaxAndLocation _maxAndLocation = new MaxAndLocation(max, location);
        return _maxAndLocation;
    }

    MaxAndLocation GetMin(float[] floatArray)
    {
        float max = floatArray[0];
        float location = 0f;
        for (int i = 0; i < floatArray.Length; i++)
        {
            if (floatArray[i] < max)
            {
                max = floatArray[i];
                location = i;
            }
        }
        MaxAndLocation _maxAndLocation = new MaxAndLocation(max, location);
        return _maxAndLocation;
    }
}
