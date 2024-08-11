using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using System.Threading.Tasks;
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

    AudioManager audioManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioManager = FindAnyObjectByType<AudioManager>();
        enemy.isBat = true;
    }

    // Update is called once per frame
    void Update()
    {
        //updateShieldTxt();
        //shieldValue.text = enemyShield.ToString();
        Dead();
    }

    public async void Tackle()
    {
        eventPopUp1.SetActive(false);
        //Deal 10 damage.

        int damage = 10;
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

        

        Debug.Log("Enemy use 'Tackle'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();

        await Task.Delay(300);
        audioManager.PlaySFX(audioManager.EnemyAtk_Scimitar);
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
            Tackle();
        }
        if (events == 1)
        {
            Tackle();
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
