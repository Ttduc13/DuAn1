using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;


public class shinigami : MonoBehaviour
{
    [SerializeField] public int health;
    int currentHealth;

    [SerializeField] public int minDamage;
    [SerializeField] public int maxDamage;

    PlayerManager player;

    private Animator anim;

    // skill
    public Transform skillPos;
    public GameObject[] prefab;
    public int index;


    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        index = UnityEngine.Random.Range(0,1);
    }

    public async void DamagePlayer()
    {
        anim.SetBool("isAttack", true);
        await Task.Delay(500);
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        Debug.Log("Player take " + damage + " damage!");
        player.health = player.health - damage;
        Instantiate(prefab[index], skillPos.position, Quaternion.identity);
        anim.SetBool("isAttack", false);
    }
}
