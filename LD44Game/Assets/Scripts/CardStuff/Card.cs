using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public float cost;
    //public float rarity;
    public virtual void Activate() { }
    Animator anim;
    public string title;
    public string description;
    public Text text;

    void Awake()
    {
        anim = GetComponent<Animator>();
        text = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        text.text = title + " \n\n" + description;
    }
}
