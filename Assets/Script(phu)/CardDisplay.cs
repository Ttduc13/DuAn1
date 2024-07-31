using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Cards card;

    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text manaText;
    public Text attackText;
    public Text healthText;

    public string damage;
    public string health;
    public string manaCost;

    void Start()
    {
        nameText.text = card.name;
        descriptionText.text = card.description;

        artworkImage.sprite = card.artwork;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();

        damage = card.attack.ToString();
        health = card.health.ToString();
        manaCost = card.manaCost.ToString();
    }

}
