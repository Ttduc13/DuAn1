using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy enemy;
    public PlayerManager player;
    public CardFunction cardFunction;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeVulnerable()
    {
        cardFunction.buff = 2;
    }
}
