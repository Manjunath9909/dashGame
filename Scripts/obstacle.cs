using UnityEngine;

public class obstacle : MonoBehaviour
{
    public float lifeSpan = 15f;
    private float timer;

    public float speef = 1f;

    public obstacleHandler releaseValve;

    void OnEnable()
    {
        timer = lifeSpan;
        lifeSpan = 15f;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //release self from object pool once the 15 seconds have passed
            releaseValve.ReleseMeFromPool(this.gameObject);
        }
        transform.Translate(Vector2.left * speef * Time.deltaTime);
    }

    public void selfDistruct()
    {
        //handling health pickups
        releaseValve.ReleseMeFromPool(this.gameObject);
    }
}
