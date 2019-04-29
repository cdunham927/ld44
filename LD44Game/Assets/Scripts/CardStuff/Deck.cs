using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public Card DrawCard(bool playerCard)
    {
        Card c = Instantiate(deck[Random.Range(0, deck.Count)], transform.position, Quaternion.identity);
        c.playerCard = playerCard;
        c.GetComponent<Button>().interactable = (playerCard) ? true : false;
        c.transform.SetParent(gameObject.transform);
        return c;
    }
}
