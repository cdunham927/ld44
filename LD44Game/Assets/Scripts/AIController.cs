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
    public float chanceToIncreaseHand = 35;
    float val = Random.Range(0, 100);
    public bool canIncreaseHand = true;

    private void Awake()
    {
        hp = maxHp;

        for (int i = 0; i < 3; i++)
        {
            Draw();
        }
    }

    public void Draw()
    {
        if (hand.Count < maxHand)
        {
            hand.Add(enemyDeck.DrawCard(false));
            hp -= 5;
        }
    }

    public void DrawThree()
    {
        if (hand.Count < maxHand)
        {
            for (int i = 0; i < 3; i++)
            {
                hand.Add(enemyDeck.DrawCard(false));
                hp -= 5;

                if (hand.Count >= maxHand) break;
            }
        }
    }

    public void DrawFive()
    {
        if (hand.Count < maxHand)
        {
            for (int i = 0; i < 5; i++)
            {
                hand.Add(enemyDeck.DrawCard(false));
                hp -= 5;

                if (hand.Count >= maxHand) break;
            }
        }
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

        if (Application.isEditor && Input.GetKeyDown(KeyCode.P))
        {
            int x = Random.Range(0, hand.Count);
            hand[x].show = true;
        }
    }

    void IncreaseHandSize()
    {
        if (canIncreaseHand)
        {
            maxHand += 1;
            hand.Add(enemyDeck.DrawCard(false));
            hp -= 10;
            val = 9000;
            canIncreaseHand = false;
        }
    }

    public void EnemyTurn()
    {
        //Big elaborate ass shit to determine what the enemy does on their turn
        //Like come on, it basically does random shit
        //Its not a smart AI
        //It cant be since I'm the one programming it
        //If you can't win against it then you just suck
        //Don't hate the player, hate the programmer

        val = Random.Range(0, 100);
        if (maxHand < 7 && val < chanceToIncreaseHand)
        {
            IncreaseHandSize();
            canIncreaseHand = false;
        }

        if (hand.Count <= 0)
        {
            int t = Random.Range(0, 3);
            if (t == 0) Draw();
            else if (t == 1 && hand.Count < 2) DrawThree();
            else if (t == 2 && hand.Count < 3 && maxHand > 5) DrawFive();
        }

        int x = Random.Range(0, hand.Count);
        hand[x].Activate();
    }
}
