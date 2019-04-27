using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Card : MonoBehaviour
{
    public float cost;
    //public float rarity;
    public virtual void Activate() { }
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
