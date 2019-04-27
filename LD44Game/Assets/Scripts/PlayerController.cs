using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public TurnController turnController;
    
    public void Attack ()
    {
        if (turnController.player_turn == true)
        {
            turnController.player_turn = false;
        }
    }
    void Update()
    {
        Attack();
    }
}
