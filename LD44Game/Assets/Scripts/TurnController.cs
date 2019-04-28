using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnController : MonoBehaviour
{
    public bool player_turn = true;
    public PlayerController player;
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

    void Update ()
    {
        if (player_turn == false)
        {
            Debug.Log("Enemy Played A Card!");
            player_turn = true;
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
