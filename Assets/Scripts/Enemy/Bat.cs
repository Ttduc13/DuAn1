using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
public class Bat : MonoBehaviour
{
    public PlayerManager player;
    public Enemy enemy;
    public int enemyShield = 0;
    public TextMeshProUGUI shieldValue;
    public GameObject shieldPopUp;
    int events;
    public GameObject eventPopUp1;
    public GameObject eventPopUp2;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy.isBat = true;
    }

    // Update is called once per frame
    void Update()
    {
        //updateShieldTxt();
        //shieldValue.text = enemyShield.ToString();
        Dead();
    }

    public void Chomp()
    {
        eventPopUp1.SetActive(false);
        //Deal 11 damage.

        int damage = 11;
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

        Debug.Log("Enemy use 'Chomp'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();
    }

    public void Thrash()
    {
        eventPopUp2.SetActive(false);
        //Deal 7 damage, gain 5 Block.
        animator.SetTrigger("attack2");
        int damage = 7;
        enemyShield = 5;

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

    public void randomEvents()
    {
        events = Random.Range(0, 2);
        if (events == 0) 
        {
            eventPopUp1.SetActive(true);
        }
        if (events == 1)
        {
            eventPopUp2.SetActive(true);
        }
    }

    public void runEvents()
    {
        if (events == 0)
        {
            Chomp();
        }
        if (events == 1)
        {
            Thrash();
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
