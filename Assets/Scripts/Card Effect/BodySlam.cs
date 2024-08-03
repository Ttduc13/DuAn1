using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySlam : MonoBehaviour
{
    public PlayerManager player;
    public CardFunction cardFunction;

    void Start()
    {
        
    }

    void Update()
    {
        attackByShield();
    }

    public void attackByShield()
    {
        cardFunction.damage = player.shield;
    }
}
