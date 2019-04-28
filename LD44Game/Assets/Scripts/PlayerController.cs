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
        if (hand.Count < maxHand)
        {
            if (enemy.hand.Count == 0;)
            {
            int x = Random.Range(0, enemy.hand.Count);
            enemy.hand[x].gameObject.transform.SetParent(playerDeck.transform);
            enemy.hand[x].playerCard = !enemy.hand[x].playerCard;
            hand.Add(enemy.hand[x]);
            enemy.hand.Remove(enemy.hand[x]);
            hp -= 10;
            }
        }
    }

    public void SeeHand ()
    {
        int x = Random.Range(0, hand.Count);
        enemy.hand[x].show = true;
        hp -= 5;
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
