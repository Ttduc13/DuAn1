using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;


public class Demon : MonoBehaviour
{
    public int health;
    public int currentHealth;

    [SerializeField] public int minDamage;
    [SerializeField] public int maxDamage;

    PlayerManager player;

    private Animator anim;

    public HealthBar healthBar;

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
    }

    public async void DamagePlayer()
    { 
        await Task.Delay(500);
        anim.SetBool("isAttack", true);
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        Debug.Log("Player take " + damage + " damage!");
        player.damagePopUp();
        player.currentHealth = player.currentHealth - damage;
        player.updatePlayerHelthBar();
        Instantiate(prefab[index], skillPos.position, Quaternion.identity);
        anim.SetBool("isAttack", false);
    }

    public void updateEnemyHelthBar()
    {
        healthBar.UpdateBar(currentHealth, health);
    }
}
