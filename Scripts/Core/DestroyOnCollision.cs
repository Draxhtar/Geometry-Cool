//Basically red objects

using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] GameObject damageSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Instantiate(damageSound);
        Destroy(gameObject);
    }
}
