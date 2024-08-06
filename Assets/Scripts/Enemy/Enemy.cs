using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;


public class Enemy : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int shield;

    public TextMeshProUGUI shieldValue;
    public GameObject shieldPopUp;

    PlayerManager player;
    CardFunction cardFunction;

    private Animator anim;

    public HealthBar healthBar;

    public Skeleton skeleton;

    public bool isVulnerable = false;
    public int vulnerableCount;

    public GameObject VulnerablePopUp;
    public TextMeshProUGUI VulnerableTxt;

    AudioManager audioManager;

    // skill
    public Transform skillPos;
    public GameObject[] prefab;
    public int index;


    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        cardFunction = FindAnyObjectByType<CardFunction>();
        anim = GetComponent<Animator>();
        currentHealth = health;
        updateEnemyHelthBar();

        audioManager = FindAnyObjectByType<AudioManager>();
    }

    void Update()
    {
        index = UnityEngine.Random.Range(0,2);
        updateShieldTxt();
        shieldValue.text = shield.ToString();
        UpdateVulnerable();
        VulnerableTxt.text = vulnerableCount.ToString();
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
        audioManager.PlaySFX(audioManager.EnemyAtk_Scimitar);
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

    public void CheckVulnerableCount()
    {
        if (vulnerableCount > 0)
        {
            vulnerableCount -= 1;
        }
        if (vulnerableCount <= 0)
        {
            vulnerableCount = 0;
        }
    }

    void UpdateVulnerable()
    {
        if (vulnerableCount > 0)
        {
            VulnerablePopUp.SetActive(true);
        }
        if (vulnerableCount <= 0)
        {
            VulnerablePopUp.SetActive(false);
        }
    }

    public bool CheckAlive()
    {
        if(currentHealth == 0)
        {
            return false;
        }
        return true;
    }
}
