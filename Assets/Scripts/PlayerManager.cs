using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int money;

    public int health;
    public int currentHealth = 0;

    public int mana = 0;
    public int currentMana;
    public TextMeshProUGUI manaValue;

    public HealthBar healthBar;

    public int damaged = 0;
    public GameObject popUpPrefab;

    public int shield = 0;
    public TextMeshProUGUI shieldValue;
    public GameObject shieldPopUp;

    public bool isVulnerable = false;
    public int vulnerableCount = 0;
    public GameObject vulnerablePopUp;
    public TextMeshProUGUI VulnerableTxt;

    public bool isDead = false;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2 )
        {
            currentHealth = PlayerPrefs.GetInt("playerHealth");
        }
        else
        {
            currentHealth = health;
        }
        updatePlayerHelthBar();

        currentMana = mana;
        updateManaValue();

        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerHelthBar();
        updateManaValue();
        updateShieldTxt();
        Vulnerabled();
        CheckDeath();

        VulnerableTxt.text = vulnerableCount.ToString();
    }

    public void updatePlayerHelthBar()
    {
        healthBar.UpdateBar(currentHealth, health);
    }

    public void updateManaValue()
    {
        manaValue.text = currentMana.ToString() + "/" + mana.ToString();
    }

    public void updateShieldTxt()
    {
        shieldValue.text = shield.ToString();
        if (shield > 0)
        {
            shieldPopUp.SetActive(true);
        }
        if (shield <= 0)
        {
            shieldPopUp.SetActive(false);
        }
    }

    public void CheckDeath()
    {
        if (currentHealth <= 0) 
        {
            isDead = true;
            animator.SetBool("isDeath", true);
        }
    }

    public void Vulnerabled()
    {
        if(vulnerableCount <= 0)
        {
            vulnerablePopUp.SetActive(false);
        }
        else
        {
            vulnerablePopUp.SetActive(true);
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
}
