using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public bool playerCard;
    public Image image;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerCard)
        {
            text.text = title + " \n\n" + description;
            text.color = Color.black;
            image.color = Color.white;
        }
        else
        {
            image.color = Color.gray;
            text.text = "";
        }
    }
}
