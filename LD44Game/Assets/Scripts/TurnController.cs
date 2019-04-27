using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnController : MonoBehaviour
{
    public bool player_turn = true;
    public PlayerController player;
    
    
    void Update ()
    {
        if (player_turn == false)
        {
            Debug.Log("Enemy Played A Card!");
            player_turn = true;
        }
    }
}
