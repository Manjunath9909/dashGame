using UnityEngine;

public class handlePlayerCollision : MonoBehaviour
{
    public GameObject mainObject;

    //this is to handle player collission
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "damageCollider")
        {
            mainObject.GetComponent<mainObject>().takeDamage(collision);
        }
        else if (collision.gameObject.name == "healCollider")
        {
            mainObject.GetComponent<mainObject>().heal(collision);
            collision.gameObject.GetComponentInParent<obstacle>().selfDistruct();
        }
    }
}
