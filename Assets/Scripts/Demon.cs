using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Demon : MonoBehaviour
{
    [SerializeField] public int health;
    int currentHealth;

    [SerializeField] public int minDamage;
    [SerializeField] public int maxDamage;

    PlayerManager player;

    private Animator anim;

    void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public async void DamagePlayer()
    {
        anim.SetBool("isAttack", true);
        await Task.Delay(500);
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        Debug.Log("Player take " + damage + " damage!");
        player.health = player.health - damage;
        anim.SetBool("isAttack", false);
    }
}
