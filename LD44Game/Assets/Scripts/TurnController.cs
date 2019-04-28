using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public bool player_turn = true;
    public PlayerController player;
    AIController enemy;

    private void Awake()
    {
        enemy = FindObjectOfType<AIController>();
    }


    void Update ()
    {
        if (player_turn == false)
        {
            enemy.EnemyTurn();
        }
    }
}
