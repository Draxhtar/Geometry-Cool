using UnityEngine;
using DG.Tweening;

//***ATTENTION: You need to have DOTWEEN setup in your project for this script to work.***
//You don't need any other components.

//This script doesn't do a check for blocks and doesn't include rotating. For that, use the identical movement script in Geometry Cool.

public class GridBasedMovementTopDown : MonoBehaviour
{
    [Header("Game Feel Values")]
    [TooltipAttribute("How much time takes for player to move once")]
    [SerializeField] float m_moveTime = 0.1f;

    [Header("Sounds")]
    [TooltipAttribute("You can leave here empty if you don't want to play any sounds")]
    [SerializeField] private GameObject[] moveSounds;

    void Update()
    {
        ManageInputs();
    }

    void ManageInputs()
    {
        //You can Edit Keycodes to change which input buttons are used

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            MovePlayerLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            MovePlayerRight();
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            MovePlayerUp();
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            MovePlayerDown();
    }
    
    private bool doesMoveSoundExists;
    private void Start()
    {
        if (moveSounds[0] != null)
            doesMoveSoundExists = false;
        else 
            doesMoveSoundExists = true;
    }
    private void PlayMoveSound()
    {
        if (doesMoveSoundExists)
            Instantiate(moveSounds[Random.Range(0, moveSounds.Length)]);
    }

    public void MovePlayerLeft()
    {
        bool isMovingValid = false;

        //Check if the block is valid by Raycasting
        isMovingValid = true;

        if (isMovingValid)
        {
            transform.DOMoveX(transform.position.x + (-1), m_moveTime);
            PlayMoveSound();
        }
    }

    public void MovePlayerRight()
    {
        bool isMovingValid = false;

        //Check if the block is valid by Raycasting
        isMovingValid = true;

        if (isMovingValid)
        {
            transform.DOMoveX(transform.position.x + (+1), m_moveTime);
            PlayMoveSound();
        }
    }

    public void MovePlayerUp()
    {
        bool isMovingValid = false;

        //Check if the block to move is valid by Raycasting
        isMovingValid = true;

        if (isMovingValid)
        {
            transform.DOMoveY(transform.position.y + (1), m_moveTime);
            PlayMoveSound();
        }
    }

    public void MovePlayerDown()
    {
        bool isMovingValid = false;

        //Check if the block is valid
        isMovingValid = true;

        if (isMovingValid)
        {
            transform.DOMoveY(transform.position.y + (-1), m_moveTime);
            PlayMoveSound();
        }
    }
}
