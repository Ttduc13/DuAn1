using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{ 
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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        updatePlayerHelthBar();

        currentMana = mana;
        updateManaValue();
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerHelthBar();
        updateManaValue();
        updateShieldTxt();
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

    public void damagePopUp()
    {
        damaged = health - currentHealth;
        if (damaged > 0) 
        {
            GameObject popUp = Instantiate(popUpPrefab, gameObject.transform.position, Quaternion.identity);
            popUp.GetComponentInChildren<TMP_Text>().text = damaged.ToString();
        }
    }
}
