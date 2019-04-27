using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float hp;

    public void TakeDamage(float amt)
    {
        hp -= amt;
    }


}
