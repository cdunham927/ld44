using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();


    private void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.O))
        {
            Card c = DrawCard();
            Debug.Log(c);
        }
    }

    public Card DrawCard()
    {
        return deck[Random.Range(0, deck.Count)];
    }
}
