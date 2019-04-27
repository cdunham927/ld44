using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Attack")]
public class AttackCard : Card
{
    public float attack;
    TurnController turn;

    private void Awake()
    {
        turn = FindObjectOfType<TurnController>();
    }

    public override void Activate()
    {
        if (turn.player_turn)
        {
            Debug.Log("The enemy takes " + attack.ToString() + " damage");
            turn.player_turn = false;
        }
    }
}
