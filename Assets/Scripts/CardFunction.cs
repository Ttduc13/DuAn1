using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEditor.Handles;

public class CardFunction : MonoBehaviour
{
    public CardDisplay cardDisplay;
    string damageStr;
    string healthStr;
    string manaStr;
    public int damage;
    public int health;
    public int manaCost;

    public PlayerManager player;
    public Demon demon;

    public GameObject shieldPopUp;

    void Start()
    {
        cardDisplay = GetComponent<CardDisplay>();
        demon = FindObjectOfType<Demon>();
        player = FindObjectOfType<PlayerManager>();

        cardDisplay.UpdateCard();

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

    public void Attack()
    {
        if (gameObject.layer == LayerMask.NameToLayer("AttackCard"))
        {
            Debug.Log("This is Attack Card");
            demon.currentHealth = demon.currentHealth - damage;
            Debug.Log("Monster take " + damage + " damage!");
            demon.updateEnemyHelthBar();
        }
    }

    public void Defend()
    {
        if(gameObject.layer == LayerMask.NameToLayer("DefendCard"))
        {
            if(health > 0)
            {
                shieldPopUp.SetActive(true);
                player.shield += health;
            }
            Debug.Log("This is Defend Card");
        }
    }
}
