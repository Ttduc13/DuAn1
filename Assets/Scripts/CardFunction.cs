using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFunction : MonoBehaviour
{
    public CardDisplay cardDisplay;
    string damageStr;
    string healthStr;
    string manaStr;
    public int damage;
    public int health;
    public int manaCost;
    void Start()
    {
        cardDisplay = GetComponent<CardDisplay>();

        damageStr = cardDisplay.damage.ToString();
        damage = int.Parse(damageStr);

        healthStr = cardDisplay.health.ToString();
        health = int.Parse(healthStr);

        manaStr = cardDisplay.manaCost.ToString();
        manaCost = int.Parse(manaStr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
