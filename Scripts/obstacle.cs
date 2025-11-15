using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float lifeSpan = 15f;
    private float timer;

    void Awake()
    {
        timer = lifeSpan;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector2.left);
    }
}
