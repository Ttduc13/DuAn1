using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

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

    AudioManager audioManager;

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

        audioManager = FindAnyObjectByType<AudioManager>();
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
            player.animator.SetTrigger("attack");
            audioManager.PlaySFX(audioManager.PlayerAtk_Sword);
            if (enemy.shield <= damage * buff) 
            {
                enemy.currentHealth = enemy.currentHealth - damage * buff + enemy.shield;
                enemy.shield = 0;
            }
            else if (enemy.shield > damage * buff)
            {
                enemy.shield -= damage * buff;
            }

            if (enemy.currentHealth <= 0)
            {
                enemy.currentHealth = 0;   
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
            enemy.isVulnerable = true;
            enemy.vulnerableCount = 3;
        }
    }
}
