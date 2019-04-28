using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Attack")]
public class AttackCard : Card
{
    public float attack;

    public override void Activate()
    {
        if (playerCard && turn.player_turn)
        {
            if (player.doubleDamage)
            {
                enemy.TakeDamage(attack * 2);
                player.doubleDamage = false;
            }
            else enemy.TakeDamage(attack);

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
