using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandController : MonoBehaviour
{
    AIController enemy;
    RectTransform rect;

    private void Awake()
    {
        enemy = FindObjectOfType<AIController>();
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        int numCards = enemy.hand.Count;
        if (numCards == 0) rect.sizeDelta = new Vector2(120, 140);
        else rect.sizeDelta = new Vector2(numCards * 110 + 10, 140);
    }
}
