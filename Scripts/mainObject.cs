using UnityEngine.UI;
using UnityEngine;

public class mainObject : MonoBehaviour
{    //player 1 imports
    public GameObject player1;
    public Rigidbody2D player1RigidBody;
    public Image player1HealthBar;
    float playerHealth;
    public float jumpIntesity = 10f;
    public GameObject player2;

    //imports for obstacles
    public obstacle obstaclePrefab;

    //imports for ui
    public uiHandler UIHandler;
    void Start()
    {
        playerHealth = 10;
    }

    void Awake()
    {
        setupObstaclePool();
    }

    public void takeDamage(Collision2D collision)
    {
        if (playerHealth > 0)
        {
            playerHealth -= 1;
            player1HealthBar.fillAmount = playerHealth / 10;
        }
        else
        {
            UIHandler.restartGame();
        }
    }

    public void jump()
    {
        player1RigidBody.AddForce(Vector2.up * jumpIntesity, ForceMode2D.Impulse);
    }

    public void setupObstaclePool()
    {
        myPool.setUpMyPool(obstaclePrefab, 10, "obstacle");
    }

    public void resetLevel()
    {
        playerHealth = 10;
        player1HealthBar.fillAmount = 1;
    }
}
