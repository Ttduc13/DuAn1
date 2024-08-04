using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using TMPro;


public class Enemy : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int shield;

    public TextMeshProUGUI shieldValue;
    public GameObject shieldPopUp;

    PlayerManager player;

    private Animator anim;

    public HealthBar healthBar;

    public Skeleton skeleton;



    // skill
    public Transform skillPos;
    public GameObject[] prefab;
    public int index;


    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        anim = GetComponent<Animator>();
        currentHealth = health;
        updateEnemyHelthBar();
    }

    void Update()
    {
        index = UnityEngine.Random.Range(0,2);
        updateShieldTxt();
        shieldValue.text = shield.ToString();
    }

    public async void DamagePlayer()
    { 
        await Task.Delay(500);
        //anim.SetBool("isAttack", true);
        //int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        //Debug.Log("Player take " + damage + " damage!");
        //player.damagePopUp();
        //player.currentHealth = player.currentHealth - damage;
        //player.updatePlayerHelthBar();
        //Instantiate(prefab[index], skillPos.position, Quaternion.identity);
        //anim.SetBool("isAttack", false);
        skeleton.runEvents();
    }

    public void randomEvents()
    {
        skeleton.randomEvents();
    }

    public void updateEnemyHelthBar()
    {
        healthBar.UpdateBar(currentHealth, health);
    }

    public void updateShieldTxt()
    {

        if (shield > 0)
        {
            shieldPopUp.SetActive(true);
        }
        if (shield <= 0)
        {
            shieldPopUp.SetActive(false);
        }
    }
}
