using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Special")]
public class SpecialCard : Card
{
    public enum specialTypes { heal };
    public specialTypes thisType = specialTypes.heal;

    public float cost;
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

    }
}
