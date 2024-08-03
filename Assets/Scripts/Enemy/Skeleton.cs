using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
public class Skeleton : MonoBehaviour
{
    public PlayerManager player;
    public int enemyShield = 0;
    public TextMeshProUGUI shieldValue;
    public GameObject shieldPopUp;
    int events;
    public GameObject eventPopUp1;
    public GameObject eventPopUp2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateShieldTxt();
        shieldValue.text = enemyShield.ToString();
    }

    public void Chomp()
    {
        eventPopUp1.SetActive(false);
        //Deal 11 damage.
        int damage = 11;
        if (player.shield > 0)
        {
            player.shield -= damage;
            if (player.shield <= 0) 
            {
                Debug.Log(player.shield);
                player.currentHealth += player.shield;
                player.shield = 0;
            }
        }
        if (player.shield == 0)
        {
            player.currentHealth -= damage;
        }
        Debug.Log("Enemy use 'Chomp'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();
    }

    public void Thrash()
    {
        eventPopUp2.SetActive(false);
        //Deal 7 damage, gain 5 Block.
        int damage = 7;
        enemyShield = 5;
        //player.currentHealth -= damage;
        if (player.shield > 0)
        {
            player.shield -= damage;
            if (player.shield <= 0)
            {
                Debug.Log(player.shield);
                player.currentHealth += player.shield;
                player.shield = 0;
            }
        }
        if (player.shield == 0)
        {
            player.currentHealth -= damage;
        }
        Debug.Log("Enemy use 'Thrash'!");
        Debug.Log("Player take " + damage + " damage!");
        player.updatePlayerHelthBar();
    }

    public void updateShieldTxt()
    {
        
        if (enemyShield > 0)
        {
            shieldPopUp.SetActive(true);
        }
        if (enemyShield < 0)
        {
            shieldPopUp.SetActive(false);
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
            Chomp();
        }
        if (events == 1)
        {
            Thrash();
        }
    }
}
