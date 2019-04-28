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
        switch(thisType)
        {
            case specialTypes.heal:
                Heal();
                break;
        }
    }

    public void Heal()
    {
        if (playerCard && turn.player_turn)
        {
            player.TakeDamage(-healAmt);
            turn.player_turn = false;
            player.hand.Remove(this);
            Destroy(gameObject);
        }
        else if (!turn.player_turn)
        {
            enemy.TakeDamage(-healAmt);
            turn.player_turn = true;
            enemy.hand.Remove(this);
            Destroy(gameObject);
        }
    }
}
