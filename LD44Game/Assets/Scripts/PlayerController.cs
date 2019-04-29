using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public TurnController turnController;
    public AIController enemy;
    TurnController turn;
    public Image health_bar;
    public Text health;

    public List<Card> hand = new List<Card>();
    public Deck playerDeck;
    public int maxHand = 3;
    public bool doubleDamage = false;
    public int attackIncrease = 0;
    public int defenseIncrease = 0;
    public bool canSpy = true;

    private void Awake()
    {
        hp = maxHp;
        turn = FindObjectOfType<TurnController>();

        for (int i = 0; i < 3; i++)
        {
            Draw();
        }
    }

    //Button On Clicks
    public void Draw()
    {
        if (turn.player_turn)
        {
            if (hand.Count < maxHand)
            {
                hand.Add(playerDeck.DrawCard(true));
                hp -= 5;
            }

            hand.RemoveAll(card => card == null);
        }
    }

    public void DrawThree()
    {
        if (turn.player_turn)
        {
            if (hand.Count < maxHand)
            {
                for (int i = 0; i < 3; i++)
                {
                    hand.Add(playerDeck.DrawCard(true));

                    if (hand.Count >= maxHand) break;
                }
                hp -= 12;
            }

            hand.RemoveAll(card => card == null);
        }
    }

    public void DrawFive()
    {
        if (turn.player_turn)
        {
            if (hand.Count < maxHand)
            {
                for (int i = 0; i < 3; i++)
                {
                    hand.Add(playerDeck.DrawCard(true));

                    if (hand.Count >= maxHand) break;
                }
                hp -= 18;
            }

            hand.RemoveAll(card => card == null);
        }
    }

    public void Bigger ()
    {
        if (turn.player_turn)
        {
            maxHand += 1;
            hand.Add(playerDeck.DrawCard(true));
            turn.battleLog.color = Color.white;
            turn.UpdateLog("You increased you max hand size to " + maxHand.ToString() + "!");
            hp -= 10;
        }
    }

    public void PowerUp ()
    {
        if (turn.player_turn)
        {
            doubleDamage = true;
            turn.battleLog.color = Color.white;
            turn.UpdateLog("You deal double damage on your next attack!");
            hp -= 15;
        }
    }

    public void EnemyDiscard()
    {
        if (turn.player_turn)
        {
            if (enemy.hand.Count > 0)
            {
                int x = Random.Range(0, enemy.hand.Count);
                turn.battleLog.color = Color.white;
                turn.UpdateLog("You made the enemy discard a " + enemy.hand[x].title + " card!");
                enemy.hand[x].Remove(enemy.hand);
                hp -= 5;
            }
        }
    }

    public void Steal ()
    {
        if (turn.player_turn)
        {
            if (hand.Count < maxHand)
            {
                if (enemy.hand.Count > 0)
                {
                    int x = Random.Range(0, enemy.hand.Count);
                    enemy.hand[x].gameObject.transform.SetParent(playerDeck.transform);
                    enemy.hand[x].playerCard = true;
                    hand.Add(enemy.hand[x]);
                    enemy.hand[x].GetComponent<Button>().interactable = true;
                    turn.battleLog.color = Color.white;
                    turn.UpdateLog("You steal a " + enemy.hand[x].title + " card!");
                    enemy.hand.Remove(enemy.hand[x]);
                    hp -= 10;
                }
            }
        }
    }

    public void Spy()
    {
        if (turn.player_turn)
        {
            if (canSpy)
            {
                int x = Random.Range(0, hand.Count);
                enemy.hand[x].show = true;
                turn.battleLog.color = Color.white;
                turn.UpdateLog("You spy on an enemies card!");
                canSpy = false;
                hp -= 5;
            }
            else
            {
                turn.battleLog.color = Color.white;
                turn.UpdateLog("You can only spy once per turn!");
            }
        }
    }
    
    public void TakeDamage(float amt)
    {
        hp -= amt;
    }

    void Update ()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.O))
        {
            if (hand.Count < maxHand)
            {
                hand.Add(playerDeck.DrawCard(true));

                hand.RemoveAll(card => card == null);
            }
        }

        //Health
        hp = Mathf.Clamp(hp, 0, maxHp);
        health_bar.fillAmount = hp / maxHp;
        health.text = "Player HP: " + hp;
    }
}
