using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/StatBoost")]
public class StatBoostCard : Card
{
    public bool defBoost;
    public bool atkBoost;
    public int effectDuration;

    public override void Activate()
    {
        if (defBoost)
        {
            //Player defense boost
            if (playerCard && turn.player_turn)
            {
                player.defenseIncrease = effectDuration;

                turn.battleLog.color = Color.white;
                turn.UpdateLog("Your defense increases!");

                turn.player_turn = false;
                player.hand.Remove(this);
                Destroy(gameObject);
            }
            //Enemy defense boost
            else if (!turn.player_turn && !playerCard)
            {
                enemy.defenseIncrease = effectDuration;

                turn.battleLog.color = Color.white;
                turn.UpdateLog("The enemies defense increases!");

                turn.player_turn = true;
                enemy.hand.Remove(this);
                Destroy(gameObject);
                enemy.hasStolen = false;
            }
        }

        if (atkBoost)
        {
            //Player attack boost
            if (playerCard && turn.player_turn)
            {
                player.attackIncrease = effectDuration;

                turn.battleLog.color = Color.white;
                turn.UpdateLog("Your attack increases!");

                turn.player_turn = false;
                player.hand.Remove(this);
                Destroy(gameObject);
            }
            //Enemy attack boost
            else if (!turn.player_turn && !playerCard)
            {
                enemy.attackIncrease = effectDuration;

                turn.battleLog.color = Color.white;
                turn.UpdateLog("The enemies attack increases!");

                turn.player_turn = true;
                enemy.hand.Remove(this);
                Destroy(gameObject);
                enemy.hasStolen = false;
            }
        }
    }
}
