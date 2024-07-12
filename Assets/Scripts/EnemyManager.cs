using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int minDamage;
    public int maxDamage;


    void DamagePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        Debug.Log("Player take " + damage + " damage!");
    }
}
