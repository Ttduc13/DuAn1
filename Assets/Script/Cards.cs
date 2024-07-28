using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Cards : ScriptableObject

{
    public string Name;
    public string description;

    public Sprite artwork;

    public int manaCost;
    public int attack;
    public int health;



    public void print()
    {
        Debug.Log(Name + ": " + description + " The card costs: " + manaCost);
    }
}
