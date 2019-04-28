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
<<<<<<< HEAD
    public List<Card> hand = new List<Card>();
    public Deck playerDeck;
    public int maxHand = 3;

    private void Awake()
    {
        hp = maxHp;

        for (int i = 0; i < 3; i++)
        {
            Draw();
        }
    }

    private void Draw()
    {
        hand.Add(playerDeck.DrawCard(true));
        hp -= 5;
    }

    public void GameOver()
    {

    }

    public void TakeDamage(float amt)
    {
        hp -= amt;
    }

=======

>>>>>>> 7506bad4400d4924dd81e4d29025cffe480722e2
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
<<<<<<< HEAD
    }
=======
    }       
>>>>>>> 7506bad4400d4924dd81e4d29025cffe480722e2
}
