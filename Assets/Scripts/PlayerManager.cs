using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{ 
    public int health;
    public int currentHealth = 0;
    public int mana = 0;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        updatePlayerHelthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePlayerHelthBar()
    {
        healthBar.UpdateBar(currentHealth, health);
    }
}
