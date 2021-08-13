using UnityEngine;
using DG.Tweening;

public class PlayerSpawnSquareBlocks : MonoBehaviour
{
    [SerializeField] GameObject m_squarePrefab; //Prefab to spawn  
    [SerializeField] Transform transformToParent;
    [SerializeField] private GameObject[] spawnSounds;
    
    [Header("Spawn Animation Tween")]
    [SerializeField] float spawnMoveTime = 0.1f;
    [SerializeField] Transform playerSprite;
    [SerializeField] float playerSquashBigSize = 1.1f;
    [SerializeField] float playerSquashNormalSize = 1;


    public void PlaySpawnSound()
    {
        Instantiate(spawnSounds[Random.Range(0, spawnSounds.Length)]);
    }

    public void SpawnBlocks() 
    {
        GameObject square1 = Instantiate(m_squarePrefab, transform.position, Quaternion.identity, transformToParent);
        square1.GetComponent<PlayerSquareBlock>().GoUp();
        
        GameObject square2 = Instantiate(m_squarePrefab, transform.position, Quaternion.identity, transformToParent);
        square2.GetComponent<PlayerSquareBlock>().GoDown();
        
        GameObject square3 = Instantiate(m_squarePrefab, transform.position, Quaternion.identity, transformToParent);
        square3.GetComponent<PlayerSquareBlock>().GoRight();
        
        GameObject square4 = Instantiate(m_squarePrefab, transform.position, Quaternion.identity, transformToParent);
        square4.GetComponent<PlayerSquareBlock>().GoLeft();
        
        //Squash animation on the center object(player)
        playerSprite.DOScale(playerSquashBigSize, spawnMoveTime/2).OnComplete(ananDoTween);

        PlaySpawnSound();

    }

    void ananDoTween() 
    {
        playerSprite.DOScale(playerSquashNormalSize, spawnMoveTime/2);
    }
}
