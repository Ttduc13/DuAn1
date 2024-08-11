using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
public class Boss : MonoBehaviour
{
    public PlayerManager player;
    public Enemy enemy;
    public int enemyShield = 0;
    public int buff = 1;
    public TextMeshProUGUI shieldValue;
    public GameObject shieldPopUp;
    int events;
    public GameObject eventPopUp1;
    public GameObject eventPopUp2;
    public GameObject eventPopUp3;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy.isBoss = true;
    }

    // Update is called once per frame
    void Update()
    {
        //updateShieldTxt();
        //shieldValue.text = enemyShield.ToString();
        Dead();
    }

    public void Rush()
    {
        CheckPlayer();
        eventPopUp1.SetActive(false);
        //Deal 16 damage.

        int damage = 16 * buff;
        animator.SetTrigger("attack1");
        if (player.shield <= damage)
        {
            player.currentHealth = player.currentHealth - damage + player.shield;
            player.shield = 0;
        }
        else if (player.shield > damage)
        {
            player.shield -= damage;
        }

        Debug.Log("Enemy use 'Rush'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();
    }

    public void Thrash()
    {
        CheckPlayer();
        eventPopUp2.SetActive(false);
        //Deal 7 damage, gain 5 Block.
        animator.SetTrigger("attack2");
        int damage = 10 * buff;
        enemyShield = 7;

        if (player.shield <= damage)
        {
            player.currentHealth = player.currentHealth - damage + player.shield;
            player.shield = 0;
        }
        else if (player.shield > damage)
        {
            player.shield -= damage;
        }

        Debug.Log("Enemy use 'Thrash'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();

        enemy.shield = enemy.shield + enemyShield;
    }

    public void SkullBash()
    {
        CheckPlayer();
        //Deal 6 damage and apply 2 Vulnerable
        animator.SetTrigger("attack2");
        eventPopUp3.SetActive(false);
        player.isVulnerable = true;
        player.vulnerableCount = 3;
        int damage = 6 * buff;
        if (player.shield <= damage)
        {
            player.currentHealth = player.currentHealth - damage + player.shield;
            player.shield = 0;
        }
        else if (player.shield > damage)
        {
            player.shield -= damage;
        }
    }

    public void CheckPlayer()
    {
        if (player.isVulnerable == true)
        {
            buff = 2;
        }
        else
        {
            buff = 1;
        }
    }

    public void randomEvents()
    {
        events = Random.Range(0, 3);
        if (events == 0) 
        {
            eventPopUp1.SetActive(true);
        }
        if (events == 1)
        {
            eventPopUp2.SetActive(true);
        }
        if (events == 2)
        {
            eventPopUp3.SetActive(true);
        }
    }

    public void runEvents()
    {
        if (events == 0)
        {
            Rush();
        }
        if (events == 1)
        {
            Thrash();
        }
        if (events == 2)
        {
            SkullBash();
        }
    }

    public void Dead()
    {
        if (enemy.CheckAlive() == false)
        {
            Debug.Log("Enemy is dead!");
            animator.SetBool("isDeath", true);
        }
    }
}
