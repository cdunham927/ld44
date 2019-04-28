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
    float val;
    public bool canIncreaseHand = true;
    public float chanceToDoubleDamage = 12.5f;
    public float chanceToSteal = 20;
    public bool canDouble = true;
    public bool doubleDamage = false;
    public bool canSteal = true;
    PlayerController player;
    public bool getNum = true;
    public int attackIncrease = 0;
    public int defenseIncrease = 0;
    //AI Difficulty
    public bool normal = true;

    private void Awake()
    {
        hp = maxHp;
        player = FindObjectOfType<PlayerController>();

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

    void DoubleDamage()
    {
        Debug.Log("Double damg");
        doubleDamage = true;
        hp -= 15;
    }

    void Steal()
    {
        Debug.Log("Stealing");
        int x = Random.Range(0, player.hand.Count);
        player.hand[x].gameObject.transform.SetParent(enemyDeck.transform);
        player.hand[x].playerCard = !player.hand[x].playerCard;
        hand.Add(player.hand[x]);
        player.hand.Remove(player.hand[x]);
        hp -= 10;
        canSteal = false;
    }

    public void EnemyTurn()
    {
        //Big elaborate ass shit to determine what the enemy does on their turn
        //Like come on, it basically does random shit
        //Its not a smart AI
        //It cant be since I'm the one programming it
        //If you can't win against it then you just suck
        //Don't hate the player, hate the programmer

        if (getNum)
        {
            val = Random.Range(0, 100);
            Debug.Log(val);
            //Double damage on next attack
            if (val <= chanceToDoubleDamage && doubleDamage == false)
            {
                DoubleDamage();
            }
            //Steal a card from the player
            else if (hand.Count < maxHand && val <= chanceToSteal && player.hand.Count > 0 && canSteal)
            {
                Steal();
            }
            else if (maxHand < 7 && val <= chanceToIncreaseHand)
            {
                IncreaseHandSize();
                canIncreaseHand = false;
            }
            getNum = false;
        }

        if (hand.Count <= 0)
        {
            int t = Random.Range(0, 5);
            if (t == 0) Draw();
            else if (t == 1 && hand.Count < 2 && hp > 25) DrawThree();
            else if (t == 2 && hand.Count < 3 && maxHand > 5 && hp > 40) DrawFive();
            else Draw();
        }

        int x = Random.Range(0, hand.Count);
        hand[x].Activate();
    }
}
