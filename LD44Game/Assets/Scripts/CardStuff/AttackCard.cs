using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Attack")]
public class AttackCard : Card
{
    public float attack;

    public override void Activate()
    {
        //Player turn
        if (playerCard && turn.player_turn)
        {
            float atk = attack;

            if (player.attackIncrease > 0) atk += 3;
            if (enemy.defenseIncrease > 0) atk -= 3;

            if (player.doubleDamage)
            {
                enemy.TakeDamage(atk * 2);
                player.doubleDamage = false;
            }
            else enemy.TakeDamage(atk);


            turn.battleLog.color = Color.white;
            turn.UpdateLog("Enemy takes " + atk.ToString() + " damage!");

            turn.player_turn = false;
            player.hand.Remove(this);
            Destroy(gameObject);

            player.attackIncrease--;
            player.defenseIncrease--;
        }
        //Enemy turn
        else if (!turn.player_turn && !playerCard)
        {
            float atk = attack;

            if (player.defenseIncrease > 0) atk -= 3;
            if (enemy.attackIncrease > 0) atk += 3;

            if (enemy.doubleDamage)
            {
                player.TakeDamage(attack * 2);
                enemy.doubleDamage = false;
            }
            else player.TakeDamage(attack);

            turn.battleLog.color = Color.white;
            turn.UpdateLog("You take " + atk.ToString() + " damage!");

            turn.player_turn = true;
            enemy.hand.Remove(this);
            Destroy(gameObject);

            enemy.attackIncrease--;
            enemy.defenseIncrease--;
        }

        
    }
}
