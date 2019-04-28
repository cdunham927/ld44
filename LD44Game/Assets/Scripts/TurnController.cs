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
        if (player_turn == false)
        {
            enemy.Invoke("EnemyTurn", 1f);
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
