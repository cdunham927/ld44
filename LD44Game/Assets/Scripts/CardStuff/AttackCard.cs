using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Cards/Attack")]
public class AttackCard : Card
{
    public float attack;

    private void Awake()
    {
        
    }

    public override void Activate()
    {
        Debug.Log("The enemy takes " + attack.ToString() + " damage");

    }
}
