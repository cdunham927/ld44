using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public TurnController turnController;
    public Image health_bar;
    public Text health;

    public List<Card> hand = new List<Card>();
    public Deck playerDeck;
    public int maxHand = 3;
    public bool doubleDamage = false;

    private void Awake()
    {
        hp = maxHp;

        for (int i = 0; i < 3; i++)
        {
            Draw();
        }
    }

    //Button On Clicks
    public void Draw()
    {
        hand.Add(playerDeck.DrawCard(true));
        hp -= 5;
    }

    public void Bigger ()
    {
        maxHand += 1;
        hp -= 15;
    }

    public void PowerUp ()
    {
        doubleDamage = true;
    }

    public void Steal ()
    {
        //
    }

    public void SeeHand ()
    {
        //
    }
    
    public void TakeDamage(float amt)
    {
        hp -= amt;
    }

    void Update ()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.O))
        {
            if (hand.Count < maxHand) hand.Add(playerDeck.DrawCard(true));
        }

        //Health
        hp = Mathf.Clamp(hp, 0, maxHp);
        health_bar.fillAmount = hp / maxHp;
        health.text = "Player HP: " + hp;
    }
}
