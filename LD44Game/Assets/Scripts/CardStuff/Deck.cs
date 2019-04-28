using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public Card DrawCard(bool playerCard)
    {
        Card c = Instantiate(deck[Random.Range(0, deck.Count)], transform.position, Quaternion.identity);
        c.playerCard = playerCard;
        c.transform.SetParent(gameObject.transform);
        return c;
    }
}
