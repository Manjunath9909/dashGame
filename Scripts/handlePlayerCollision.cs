using UnityEngine;

public class handlePlayerCollision : MonoBehaviour
{
    public GameObject mainObject;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "damageCollider")
        {
            mainObject.GetComponent<mainObject>().takeDamage(collision);
        }
    }
}
