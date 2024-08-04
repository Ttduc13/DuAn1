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

    public int buff = 1;

    public PlayerManager player;
    public Enemy enemy;

    public GameObject shieldPopUp;

    public bool isVulnerable = false;

    void Start()
    {
        cardDisplay = GetComponent<CardDisplay>();
        enemy = FindObjectOfType<Enemy>();
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

            //if (enemy.shield > 0)
            //{
            //    enemy.shield -= damage;
            //    if (enemy.shield <= 0)
            //    {
            //        Debug.Log(enemy.shield);
            //        enemy.currentHealth += enemy.shield;
            //        enemy.shield = 0;
            //    }
            //}
            //if (enemy.shield == 0)
            //{
            //    enemy.currentHealth -= damage;
            //}

            if (enemy.shield <= damage * buff) 
            {
                enemy.currentHealth = enemy.currentHealth - damage * buff + enemy.shield;
                enemy.shield = 0;
            }
            else if (enemy.shield > damage * buff)
            {
                enemy.shield -= damage * buff;
            }

            Debug.Log("Monster take " + damage * buff + " damage!");
            enemy.updateEnemyHelthBar();
        }
    }

    public void Defend()
    {
        if(gameObject.layer == LayerMask.NameToLayer("DefendCard"))
        {
            if (health > 0) 
            {
                player.shield += health;
            }
            Debug.Log("This is Defend Card");
        }
    }

    public void EffectCard()
    {
        //Vulnerable
        if (isVulnerable == true)
        {
            buff = 2;
        }
        else
        {
            buff = 1;
        }

    }
}
