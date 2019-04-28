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

    private void Awake()
    {
        enemy = FindObjectOfType<AIController>();
        gameOverCanvas.SetActive(false);
    }

    void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }

    public void Restart ()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update ()
    {
        if (player_turn == false)
        {
            enemy.Invoke("EnemyTurn", 0.5f);
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
    }
}
