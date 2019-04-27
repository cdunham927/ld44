using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public TurnController turnController;
    public Image health_bar;
    public Text health;
    
    void GameOver()
    {

    }
    void Update ()
    {
        //Health
        health_bar.fillAmount = hp / maxHp;
        health.text = "Player HP: " + hp;
    }
        
        
        
}
