using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public List<Card> hand = new List<Card>();
    public Image health_bar;
    public Text health;
    public Deck enemyDeck;
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
        hand.Add(enemyDeck.DrawCard(false));
        hp -= 5;
    }

    public void TakeDamage(float amt)
    {
        hp -= amt;
    }

    private void Update()
    {
        //Health
        hp = Mathf.Clamp(hp, 0, maxHp);
        health_bar.fillAmount = hp / maxHp;
        health.text = "Enemy HP: " + hp;
    }

    public void EnemyTurn()
    {
        //Big elaborate ass shit to determine what the enemy does on their turn
        if (hand.Count <= 0) Draw();
        int x = Random.Range(0, hand.Count);
        hand[x].Activate();
    }
}
