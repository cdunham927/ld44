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
            DefenseBoost();
        }

        if (atkBoost)
        {
            AttackBoost();
        }
    }

    public void DefenseBoost()
    {

    }

    public void AttackBoost()
    {

    }
}
