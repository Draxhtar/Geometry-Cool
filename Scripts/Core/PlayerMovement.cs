using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [Header("Game Feel Values")]
    [SerializeField]
    float m_rotateTime = 0.1f;
    [SerializeField]
    float m_moveTime = 0.1f;

    private int m_rotation_i;
    [SerializeField] GameObject m_ghostCollider;
    [SerializeField] float rayDistance = 1f;
    [SerializeField] Animator animator;

    [SerializeField] private GameObject[] footstepSounds;
    [SerializeField] private GameObject[] rotateSounds;

    public void Step()
    {
        Instantiate(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }
    void Rotate() 
    {
        Instantiate(rotateSounds[0]);
    }

    void Start()
    {
        m_rotation_i = 0;
    }

    public void MovePlayerLeft()
    {
        //Check if the block is valid
        bool isMovingValid = false;
        PlayerSquareBlock[] mySquares = GetComponentsInChildren<PlayerSquareBlock>();
        if (mySquares.Length == 0)
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, new Vector3(-1, 0, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
            if (hits.Length == 0) 
            {
                isMovingValid = true; 
                Debug.Log("No Hits");
            }
        }
        else 
        {
            for (int i = 0; i < mySquares.Length; i++)
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(mySquares[i].transform.position, new Vector3(-1, 0, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
                if (hits.Length > 0)
                {
                    isMovingValid = false;
                    break;
                }
                else
                {
                    isMovingValid = true;
                }
            }
        }
        if (isMovingValid) 
        {
            transform.DOMoveX(transform.position.x + (-1), m_moveTime);
            Step();
        }
        else 
        {
            animator.SetTrigger("FailLeft");
        }
    }

    public void MovePlayerRight()
    {
        //Check if the block is valid
        bool isMovingValid = false;
        PlayerSquareBlock[] mySquares = GetComponentsInChildren<PlayerSquareBlock>();
        if (mySquares.Length == 0)
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, new Vector3(1, 0, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
            if (hits.Length == 0)
            {
                isMovingValid = true;
                Debug.Log("No Hits");
            }
        }
        else
        {
            for (int i = 0; i < mySquares.Length; i++)
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(mySquares[i].transform.position, new Vector3(1, 0, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
                if (hits.Length > 0)
                {
                    isMovingValid = false;
                    break;
                }
                else
                {
                    isMovingValid = true;
                    continue;
                }
            }
        }
        if (isMovingValid)
        {
            transform.DOMoveX(transform.position.x + (1), m_moveTime);
            Step();
        }
        else
        {
            animator.SetTrigger("FailRight");
        }
    }

    public void MovePlayerUp()
    {
        //Check if the block is valid
        bool isMovingValid = false;
        PlayerSquareBlock[] mySquares = GetComponentsInChildren<PlayerSquareBlock>();
        if (mySquares.Length == 0)
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, new Vector3(0, 1, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
            if (hits.Length == 0)
            {
                isMovingValid = true;
                Debug.Log("No Hits");
            }
        }
        else
        {
            for (int i = 0; i < mySquares.Length; i++)
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(mySquares[i].transform.position, new Vector3(0, 1, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
                if (hits.Length > 0)
                {
                    isMovingValid = false;
                    break;
                }
                else
                {
                    isMovingValid = true;
                }
            }
        }
        if (isMovingValid) { 
            transform.DOMoveY(transform.position.y + (1), m_moveTime);
            Step();
        }
        else
        {
            animator.SetTrigger("FailUp");
        }
    }

    public void MovePlayerDown()
    {
        //Check if the block is valid
        bool isMovingValid = false;
        PlayerSquareBlock[] mySquares = GetComponentsInChildren<PlayerSquareBlock>();
        if (mySquares.Length == 0)
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, new Vector3(0, -1, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
            if (hits.Length == 0)
            {
                isMovingValid = true;
                Debug.Log("No Hits");
            }
        }
        else
        {
            for (int i = 0; i < mySquares.Length; i++)
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(mySquares[i].transform.position, new Vector3(0, -1, 0), rayDistance, 1 << LayerMask.NameToLayer("Wall"));
                if (hits.Length > 0)
                {
                    isMovingValid = false;
                    break;
                }
                else
                {
                    isMovingValid = true;
                }
            }
        }
        if (isMovingValid) { 
            transform.DOMoveY(transform.position.y + (-1), m_moveTime);
            Step();
        }
        else
        {
            animator.SetTrigger("FailDown");
        }
    }

    public void RotatePlayerClockwise()
    {
        int lastRotation_i = m_rotation_i;
        if (m_rotation_i != 3)
        {
            m_rotation_i += 1;
        }
        else if (m_rotation_i == 3) 
        {
            m_rotation_i = 0;
        }

        bool isRotationValid = false;
        PlayerSquareBlock[] mySquares = GetComponentsInChildren<PlayerSquareBlock>();
        float rayDistanceRotation = (mySquares.Length / 4) ;
        if (mySquares.Length == 0)
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, transform.right, rayDistanceRotation, 1 << LayerMask.NameToLayer("Wall"));
            if (hits.Length == 0)
            {
                isRotationValid = true;
                Debug.Log("No Hits");
            }
        }
        else
        {
            for (int i = 0; i < mySquares.Length; i++)
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(mySquares[i].transform.position, transform.right, rayDistanceRotation, 1 << LayerMask.NameToLayer("Wall"));
                if (hits.Length > 0)
                {
                    isRotationValid = false;
                    break;
                }
                else
                {
                    isRotationValid = true;
                    continue;
                }
            }
        }
        if (isRotationValid) 
        { 
            switch (m_rotation_i)
            {
                case 0:
                    transform.DORotate(new Vector3(0, 0, 0), m_rotateTime);
                    break;
                case 1:
                    transform.DORotate(new Vector3(0, 0, -90), m_rotateTime);
                    break;
                case 2:
                    transform.DORotate(new Vector3(0, 0, -180), m_rotateTime);
                    break;
                case 3:
                    transform.DORotate(new Vector3(0, 0, -270), m_rotateTime);
                    break;
            }
            Rotate();
        }
        else
        {
            m_rotation_i = lastRotation_i;
            animator.SetTrigger("FailClockwise");
        }
        
    }

    public void RotatePlayerAntiClockwise()
    {
        int lastRotation_i = m_rotation_i;
        if (m_rotation_i != 0)
        {
            m_rotation_i -= 1;
        }
        else if (m_rotation_i == 0)
        {
            m_rotation_i = 3;
        }
        bool isRotationValid = false;
        PlayerSquareBlock[] mySquares = GetComponentsInChildren<PlayerSquareBlock>();
        float rayDistanceRotation = (mySquares.Length / 4) ;
        if (mySquares.Length == 0)
        {
            RaycastHit2D[] hits;
            hits = Physics2D.RaycastAll(transform.position, -transform.right, rayDistanceRotation, 1 << LayerMask.NameToLayer("Wall"));
            if (hits.Length == 0)
            {
                isRotationValid = true;
                Debug.Log("No Hits");
            }
        }
        else
        {
            for (int i = 0; i < mySquares.Length; i++)
            {
                RaycastHit2D[] hits;
                hits = Physics2D.RaycastAll(mySquares[i].transform.position, -transform.right, rayDistanceRotation, 1 << LayerMask.NameToLayer("Wall"));
                if (hits.Length > 0)
                {
                    isRotationValid = false;
                    break;
                }
                else
                {
                    isRotationValid = true;
                    continue;
                }
            }
        }
        if (isRotationValid)
        {
            switch (m_rotation_i)
            {
                case 0:
                    transform.DORotate(new Vector3(0, 0, 0), m_rotateTime);
                    break;
                case 1:
                    transform.DORotate(new Vector3(0, 0, -90), m_rotateTime);
                    break;
                case 2:
                    transform.DORotate(new Vector3(0, 0, -180), m_rotateTime);
                    break;
                case 3:
                    transform.DORotate(new Vector3(0, 0, -270), m_rotateTime);
                    break;
            }
            Rotate();
        }
        else
        {
            m_rotation_i = lastRotation_i;
            animator.SetTrigger("FailAntiClockwise");
        }
        
    }

    void CheckIsBlockValid() 
    {

    }
}
