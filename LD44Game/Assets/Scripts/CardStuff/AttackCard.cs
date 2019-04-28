using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Attack")]
public class AttackCard : Card
{
    public float attack;
    TurnController turn;
    PlayerController player;
    AIController enemy;

    private void Awake()
    {
        turn = FindObjectOfType<TurnController>();
        player = FindObjectOfType<PlayerController>();
        enemy = FindObjectOfType<AIController>();
    }

    public override void Activate()
    {
        if (playerCard && turn.player_turn)
        {
            enemy.TakeDamage(attack);
            turn.player_turn = false;
            player.hand.Remove(this);
            Destroy(gameObject);
        }
        else if (!turn.player_turn)
        {
            player.TakeDamage(attack);
            turn.player_turn = true;
            enemy.hand.Remove(this);
            Destroy(gameObject);
        }
    }
}
