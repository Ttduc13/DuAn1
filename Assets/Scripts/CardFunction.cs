using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFunction : MonoBehaviour
{
    public Cards card;
    string damageStr;
    public int damage;
    void Start()
    {
        damageStr = card.attack.ToString();
        Debug.Log(damageStr);
        damage = int.Parse(damageStr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
