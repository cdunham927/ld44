using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public bool player_turn = true;
    public PlayerController player;
<<<<<<< HEAD
    AIController enemy;

    private void Awake()
    {
        enemy = FindObjectOfType<AIController>();
    }

=======
    public AIController AI;
    public Text gameOverText;
    public GameObject gameOverCanvas;
    
    void Awake ()
    {
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
>>>>>>> 7506bad4400d4924dd81e4d29025cffe480722e2

    void Update ()
    {
        if (player_turn == false)
        {
            enemy.EnemyTurn();
        }

        if (player.hp <= 0)
        {
            GameOver();
            gameOverText.text = "Enemy Wins!";
        }

        if (AI.hp <= 0)
        {
            GameOver();
            gameOverText.text = "You Win!";            
        }
    }
}
