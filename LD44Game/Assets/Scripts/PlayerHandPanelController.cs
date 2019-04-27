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
        //1 - 120
        //2 - 230
        //int numCards = player.handSize;
        //rect.sizeDelta = new Vector2(numCards * 110 + 10, 150);
    }
}
