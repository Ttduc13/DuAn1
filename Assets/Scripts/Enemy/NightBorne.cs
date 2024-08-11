using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using System.Threading.Tasks;
public class NightBorne : MonoBehaviour
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

    public Animator animator;

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        enemy.isNightBorne = true;
    }

    // Update is called once per frame
    void Update()
    {
        //updateShieldTxt();
        //shieldValue.text = enemyShield.ToString();
        Dead();
    }

    public async void Stab()
    {
        CheckPlayer();
        eventPopUp1.SetActive(false);
        //Deal 13 damage.

        int damage = 13 * buff;
        animator.SetTrigger("attack");
        if (player.shield <= damage)
        {
            player.currentHealth = player.currentHealth - damage + player.shield;
            player.shield = 0;
        }
        else if (player.shield > damage)
        {
            player.shield -= damage;
        }

        Debug.Log("Enemy use 'Stab'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();

        await Task.Delay(300);
        audioManager.PlaySFX(audioManager.PlayerAtk_Sword);
    }

    public async void Scrape()
    {
        CheckPlayer();
        //Deal 8 damage and apply 2 Vulnerable.
        animator.SetTrigger("attack");
        int damage = 8 * buff;
        eventPopUp2.SetActive(false);
        player.isVulnerable = true;
        player.vulnerableCount = 3;

        if (player.shield <= damage)
        {
            player.currentHealth = player.currentHealth - damage + player.shield;
            player.shield = 0;
        }
        else if (player.shield > damage)
        {
            player.shield -= damage;
        }

        Debug.Log("Enemy use 'Scrape'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();

        enemy.shield = enemy.shield + enemyShield;

        await Task.Delay(300);
        audioManager.PlaySFX(audioManager.EnemyAtk_Scimitar);
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
            Stab();
        }
        if (events == 1)
        {
            Scrape();
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
