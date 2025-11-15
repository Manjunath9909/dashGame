using System;
using TMPro;
using UnityEngine;

public class uiHandler : MonoBehaviour
{
    public mainObject gameRunner;
    public Canvas gameplayCanvas;
    public Canvas startGameCanvas;
    public Canvas endGameCanvas;
    public TextMeshProUGUI scoreCard;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && startGameCanvas.enabled == false)
        {
            endGame("Paused", "");
        }
    }

    void Awake()
    {
        //enabling and disabling canvases
        startGameCanvas.enabled = true;
        gameplayCanvas.enabled = false;
        endGameCanvas.enabled = false;
    }

    public void startGame()
    {
        print("start game");
        gameRunner.startLevel();
        startGameCanvas.enabled = false;
        gameplayCanvas.enabled = true;
        endGameCanvas.enabled = false;
    }

    public void restartGame()
    {
        print("restarting game");
        gameRunner.resetLevel();
        startGameCanvas.enabled = false;
        gameplayCanvas.enabled = true;
        endGameCanvas.enabled = false;
    }

    public void exitGame()
    {
        print("exit game");
        Application.Quit();
    }

    public void mainMenu()
    {
        print("main menu");
        startGameCanvas.enabled = true;
        gameplayCanvas.enabled = false;
        endGameCanvas.enabled = false;
    }

    public void endGame(String message1, String message2)
    {
        startGameCanvas.enabled = false;
        gameplayCanvas.enabled = false;
        endGameCanvas.enabled = true;
    }

    public void updateScore(int score)
    {
        scoreCard.text = "Score : " + score.ToString();
    }
}
