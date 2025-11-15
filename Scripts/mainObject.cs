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
    public bool gameRunning;
    //imports for ui
    public uiHandler UIHandler;
    float scoreStep = 1.5f;
    float lastUpdate = 0;
    int score = 0;
    void Start()
    {
        gameRunning = false;
        playerHealth = 10;
        lastUpdate = 0f;
        score = 0;
    }

    void Update()
    {
        if (gameRunning)
        {
            lastUpdate += Time.deltaTime;
            if (lastUpdate >= scoreStep)
            {
                score += 1;
                UIHandler.updateScore(score);
                lastUpdate -= scoreStep;
            }
        }
        else
        {
            //mostly to handle new game and level reset
            UIHandler.updateScore(0);
        }
    }

    public void takeDamage(Collision2D collision)
    {
        if (playerHealth > 0)
        {
            print("took damage");
            playerHealth -= 1;
            player1HealthBar.fillAmount = playerHealth / 10;
        }
        else if (playerHealth == 0)
        {
            gameRunning = false;
            UIHandler.endGame("You died!", "High score was : " + score.ToString());
        }
    }

    public void jump()
    {
        player1RigidBody.AddForce(Vector2.up * jumpIntesity, ForceMode2D.Impulse);
    }

    public void resetLevel()
    {
        gameRunning = true;
        UIHandler.updateScore(0);
        playerHealth = 10;
        player1HealthBar.fillAmount = 1;
        score = 0;
    }

    public void startLevel()
    {
        UIHandler.updateScore(0);
        gameRunning = true;
        playerHealth = 10;
        player1HealthBar.fillAmount = 1;
        score = 0;
    }
}
