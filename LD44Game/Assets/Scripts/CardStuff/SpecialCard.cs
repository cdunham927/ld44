using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Special")]
public class SpecialCard : Card
{
    public enum specialTypes { heal };
    public specialTypes thisType = specialTypes.heal;

    //Stats related to the cards specialType
    public float healAmt;

    public override void Activate()
    {
        if (thisType == specialTypes.heal)
        {
            //Player heal
            if (playerCard && turn.player_turn)
            {
                turn.battleLog.color = Color.white;
                turn.UpdateLog("You heal " + healAmt.ToString() + " health!");

                player.TakeDamage(-healAmt);
                turn.player_turn = false;
                player.hand.Remove(this);
                Destroy(gameObject);

                player.attackIncrease--;
                player.defenseIncrease--;
                player.canSpy = true;
            }
            //Enemy heal
            else if (!turn.player_turn && !playerCard)
            {
                turn.battleLog.color = Color.white;
                turn.UpdateLog("The enemy heals " + healAmt.ToString() + " health!");

                enemy.TakeDamage(-healAmt);
                turn.player_turn = true;
                enemy.hand.Remove(this);
                Destroy(gameObject);

                enemy.attackIncrease--;
                enemy.defenseIncrease--;
                enemy.hasStolen = false;
            }
        }
    }
}
