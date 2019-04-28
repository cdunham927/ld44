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
    public Image health_bar;
    public Text health;

    public List<Card> hand = new List<Card>();
    public Deck playerDeck;
    public int maxHand = 3;
    public bool doubleDamage = false;
    public int attackIncrease = 0;
    public int defenseIncrease = 0;

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
        if (hand.Count < maxHand)
        {
            hand.Add(playerDeck.DrawCard(true));
            hp -= 5;
        }
        
        hand.RemoveAll(card => card == null);
    }

    public void DrawThree()
    {

        if (hand.Count < maxHand)
        {
            for (int i = 0; i < 3; i++)
            {
                hand.Add(playerDeck.DrawCard(false));
                hp -= 4;

                if (hand.Count >= maxHand) break;
            }
        }

        hand.RemoveAll(card => card == null);
    }

    public void DrawFive()
    {

        if (hand.Count < maxHand)
        {
            for (int i = 0; i < 3; i++)
            {
                hand.Add(playerDeck.DrawCard(false));
                hp -= 3;

                if (hand.Count >= maxHand) break;
            }
        }

        hand.RemoveAll(card => card == null);
    }

    public void Bigger ()
    {
        maxHand += 1;
        hp -= 15;
    }

    public void PowerUp ()
    {
        doubleDamage = true;
        hp -= 15;
    }

    public void Steal ()
    {
        if (hand.Count < maxHand)
        {
            int x = Random.Range(0, enemy.hand.Count);
            enemy.hand[x].gameObject.transform.SetParent(playerDeck.transform);
            enemy.hand[x].playerCard = true;
            hand.Add(enemy.hand[x]);
            enemy.hand.Remove(enemy.hand[x]);
            hp -= 10;
        }
    }

    public void SeeHand ()
    {
        int x = Random.Range(0, hand.Count);
        hand[x].show = true;
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
