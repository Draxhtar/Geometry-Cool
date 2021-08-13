using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Key Bindings")]
    [SerializeField] KeyCode input_left = KeyCode.LeftArrow;
    [SerializeField] KeyCode input_right = KeyCode.RightArrow;
    [SerializeField] KeyCode input_up = KeyCode.UpArrow;
    [SerializeField] KeyCode input_down = KeyCode.DownArrow;

    [SerializeField] KeyCode rotate_clockwise = KeyCode.E;
    [SerializeField] KeyCode rotate_anti_clockwise = KeyCode.Q;

    [Header("References")]
    [SerializeField] PlayerMovement m_playerMovement;
    [SerializeField] PlayerSpawnSquareBlocks m_spawnBlocks;

    void Update()
    {
        ListenForInput();
    }

    void ListenForInput() 
    {
        #region Moving
        if (Input.GetKeyDown(input_left))
        {
            if (m_playerMovement != null)
                m_playerMovement.MovePlayerLeft();
        }

        if (Input.GetKeyDown(input_right))
        {
            if (m_playerMovement != null)
                m_playerMovement.MovePlayerRight();
        }

        if (Input.GetKeyDown(input_up))
        {
            if (m_playerMovement != null)
                m_playerMovement.MovePlayerUp();
        }

        if (Input.GetKeyDown(input_down))
        {
            if (m_playerMovement != null)
                m_playerMovement.MovePlayerDown();
        }
        #endregion

        if (Input.GetKeyDown(rotate_clockwise))
        {
            if (m_playerMovement != null)
                m_playerMovement.RotatePlayerClockwise();
        }

        if (Input.GetKeyDown(rotate_anti_clockwise))
        {
            if (m_playerMovement != null)
                m_playerMovement.RotatePlayerAntiClockwise();
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            m_spawnBlocks.SpawnBlocks();
        }
    }
}
