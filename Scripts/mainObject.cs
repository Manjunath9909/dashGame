using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class mainObject : MonoBehaviour
{    //player 1 imports
    public GameObject player1;
    public obstacleHandler level;
    public Rigidbody2D player1RigidBody;
    public Image player1HealthBar;
    float playerHealth;
    public float jumpIntesity = 10f;
    public Rigidbody2D player2;
    public bool gameRunning;
    //imports for ui
    public uiHandler UIHandler;
    float scoreStep = 1.5f;
    float lastUpdate = 0;
    public int score = 0;
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
                //updating the score at a certain interval
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

    //take damage from obstacles and update ui to denote the damage
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
            level.resetObstacles();
            UIHandler.endGame("You died!", "High score was : " + score.ToString());
        }
    }

    // heal from the green health ord pickups
    public void heal(Collision2D collision)
    {
        if (playerHealth < 10)
        {
            playerHealth += 1;
            player1HealthBar.fillAmount = player1HealthBar.fillAmount + 0.1f;
        }
    }

    //jump jump jump
    public void jump()
    {
        player1RigidBody.AddForce(Vector2.up * jumpIntesity, ForceMode2D.Impulse);
        //this coroutine adds delay of 1.5 seconds between player 1 and 2 reacting to input
        StartCoroutine(jumpAfter(1.5f));
    }

    //resetting the level 
    public void resetLevel()
    {
        gameRunning = true;
        UIHandler.updateScore(0);
        playerHealth = 10;
        player1HealthBar.fillAmount = 1;
        level.resetObstacles();
        score = 0;
    }

    //handling first time launch mostly and return launcher or UI button calls 
    public void startLevel()
    {
        UIHandler.updateScore(0);
        level.resetObstacles();
        gameRunning = true;
        playerHealth = 10;
        player1HealthBar.fillAmount = 1;
        score = 0;
    }

    //coroutine that executes 1.5 seconds after the player character reacts to the input  
    private System.Collections.IEnumerator jumpAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        player2.AddForce(Vector2.up * jumpIntesity, ForceMode2D.Impulse);
    }
}
