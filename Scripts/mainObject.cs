using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.PlasticSCM.Editor.WebApi;

public class mainObject : MonoBehaviour
{    //player 1 imports
    public GameObject player1;
    public Rigidbody2D player1RigidBody;
    public Image player1HealthBar;
    float playerHealth;
    public GameObject player2;
    public GameObject movingObstacles;
    void Start()
    {
        playerHealth = 10;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        playerHealth -= 1;
        player1HealthBar.fillAmount = playerHealth / 10;
    }

    public void jump()
    {

    }
}
