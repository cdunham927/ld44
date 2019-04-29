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
    TurnController turn;
    PlayerController player;
    public bool getNum = true;
    public int attackIncrease = 0;
    public int defenseIncrease = 0;
    public bool hasStolen;
    public bool startedTurn = false;
    //AI Difficulty
    public bool hard = true;

    private void Awake()
    {
        hard = MusicController.music.enemyDifficulty;

        hp = maxHp;
        turn = FindObjectOfType<TurnController>();
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
                hp -= 4;

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
                hp -= 3;

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
            if (hand[x] != null) hand[x].show = true;
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
            turn.battleLog.color = Color.white;
            turn.UpdateLog("Enemy increased their hand size!");
        }
    }

    void DoubleDamage()
    {
        doubleDamage = true;
        val = 9000;
        hp -= 15;
        turn.battleLog.color = Color.white;
        turn.UpdateLog("Enemy does double damage on their next attack!");
    }

    void Steal()
    {
        if (canSteal && !hasStolen)
        {
            int x = Random.Range(0, player.hand.Count);
            player.hand[x].gameObject.transform.SetParent(enemyDeck.transform);
            player.hand[x].playerCard = false;
            player.hand[x].show = false;
            hand.Add(player.hand[x]);
            player.hand[x].GetComponent<Button>().interactable = false;
            turn.battleLog.color = Color.white;
            turn.UpdateLog("Enemy has stolen a " + player.hand[x].title + " card!");
            player.hand.Remove(player.hand[x]);
            hp -= 10;
            hasStolen = true;
            val = 9000;
            canSteal = false;
        }
    }

    public void EnemyStartTurn()
    {
        //Big elaborate ass shit to determine what the enemy does on their turn
        //Like come on, it basically does random shit
        //Its not a smart AI
        //It cant be since I'm the one programming it
        //If you can't win against it then you just suck
        //Don't hate the player, hate the programmer
        
        if (!hard) {
            if (getNum && startedTurn)
            {
                val = Random.Range(0, 100);
                //Double damage on next attack
                if (val <= chanceToDoubleDamage && doubleDamage == false && hp > 35)
                {
                    DoubleDamage();
                }
                //Steal a card from the player
                else if (hand.Count < maxHand && val <= chanceToSteal && player.hand.Count > 0 && hp > 15)
                {
                    Steal();
                }
                else if (maxHand < 7 && val <= chanceToIncreaseHand && hp > 15)
                {
                    IncreaseHandSize();
                    canIncreaseHand = false;
                }
                getNum = false;
            }
        }
        startedTurn = false;
        Invoke("EnemyEndTurn", 1f);
    }

    public void EnemyEndTurn()
    {
        //Need to fix this so they can draw cards when they want to
        if (hand.Count <= 0)
        {
            int t = Random.Range(0, 4);
            if (t == 0) Draw();
            else if (t == 1 && hand.Count < 2 && hp > 25) DrawThree();
            else if (t == 2 && hand.Count < 3 && maxHand > 5 && hp > 40) DrawFive();
            else if (t == 3 && hand.Count < 3 && hp > 25) DrawThree();
        }

        if (hand.Count > 0)
        {
            int x = Random.Range(0, hand.Count);
            hand[x].Activate();
        }
        else
        {
            Draw();
            hand[0].Activate();
        }
    }
}
