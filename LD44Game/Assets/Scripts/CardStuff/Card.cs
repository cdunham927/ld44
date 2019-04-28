using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour
{
    public virtual void Activate() { }
    Animator anim;
    public string title;
    public string description;
    public Text text;
    public bool playerCard;
    public Image image;
    public bool show = false;

    public TurnController turn;
    public PlayerController player;
    public AIController enemy;

    private void Awake()
    {
        turn = FindObjectOfType<TurnController>();
        player = FindObjectOfType<PlayerController>();
        enemy = FindObjectOfType<AIController>();
        anim = GetComponent<Animator>();

        show = false;
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
            text.color = Color.black;
            if (!show) text.text = "";
            else text.text = title + " \n\n" + description;
        }
    }
}
