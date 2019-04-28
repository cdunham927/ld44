using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public bool player_turn = true;
    public PlayerController player;
    AIController enemy;
    public GameObject gameOverCanvas;
    public Text gameOverText;
    public Text battleLog;
    public float lerpSpd;

    private void Awake()
    {
        enemy = FindObjectOfType<AIController>();
        gameOverCanvas.SetActive(false);
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update ()
    {
        if (player_turn == false && !enemy.startedTurn && enemy.hp > 0 && player.hp > 0)
        {
            enemy.startedTurn = true;
            enemy.getNum = true;
            enemy.canIncreaseHand = true;
            enemy.canSteal = true;
            enemy.canDouble = true;
            enemy.Invoke("EnemyStartTurn", 1f);
        }

        if (player.hp <= 0)
        {
            GameOver();
            gameOverText.text = "Enemy Wins!";
        }

        if (enemy.hp <= 0)
        {
            GameOver();
            gameOverText.text = "You Win!";            
        }

        battleLog.color = Color.Lerp(battleLog.color, new Color(1, 1, 1, 0), Time.deltaTime * lerpSpd);
    }

    public void UpdateLog(string text)
    {
        battleLog.text = text;
    }
}
