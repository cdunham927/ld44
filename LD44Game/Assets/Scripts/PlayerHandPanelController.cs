using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandPanelController : MonoBehaviour
{
    PlayerController player;
    RectTransform rect;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        int numCards = player.hand.Count;
        if (numCards == 0) rect.sizeDelta = new Vector2(120, 140);
        else rect.sizeDelta = new Vector2(numCards * 110 + 10, 140);
    }
}
