using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    PlayerManager player;
    MenuManager menu;

    public TextMeshProUGUI healthValue;
    public TextMeshProUGUI moneyValue;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthValue.text = player.currentHealth.ToString() + "/" + player.health.ToString();

        moneyValue.text = player.money.ToString();

    }
}
