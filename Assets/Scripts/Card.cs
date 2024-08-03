using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	public bool hasBeenPlayed;
	public int handIndex;

	MenuManager mm;

	private Animator anim;
	private Animator camAnim;

	public GameObject effect;
	public GameObject hollowCircle;

    GameManager gameManager;
	Enemy demon;
	PlayerManager player;

	CardDisplay cardDisplay;
	CardFunction cardFunction;

    private void Start()
	{
		mm = FindObjectOfType<MenuManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();

		demon = FindObjectOfType<Enemy>();
        player = FindObjectOfType<PlayerManager>();

        cardDisplay = GetComponent<CardDisplay>();
		cardFunction = GetComponent<CardFunction>();
    }
	private void OnMouseDown()
	{
		if (gameManager.isPlayerTurn == true)
		{
			if (player.mana > 0 && cardFunction.manaCost <= player.mana)
			{
                if (!hasBeenPlayed)
                {
                    Instantiate(hollowCircle, transform.position, Quaternion.identity);

                    camAnim.SetTrigger("shake");
                    anim.SetTrigger("move");

                    transform.position += Vector3.up * 3f;
                    hasBeenPlayed = true;
                    mm.availableCardSlots[handIndex] = true;
                    Invoke("MoveToDiscardPile", 1f);

      //              if (cardFunction.damage > 0)
      //              {
      //                  demon.currentHealth = demon.currentHealth - cardFunction.damage;
      //                  Debug.Log("Monster take " + cardFunction.damage + " damage!");
						//demon.updateEnemyHelthBar();
      //              }

                    if (cardFunction.health > 0)
                    {
                        player.currentHealth = player.currentHealth + cardFunction.health;
                        if (player.currentHealth > player.health)
                        {
                            player.currentHealth = player.health;
                        }
						player.updatePlayerHelthBar();
                    }

					cardFunction.Attack();
					cardFunction.Defend();

					player.currentMana = player.currentMana - cardFunction.manaCost;
					player.updateManaValue();
                }
            }
   //         if (!hasBeenPlayed)
   //         {
   //             Instantiate(hollowCircle, transform.position, Quaternion.identity);

   //             camAnim.SetTrigger("shake");
   //             anim.SetTrigger("move");

   //             transform.position += Vector3.up * 3f;
   //             hasBeenPlayed = true;
   //             mm.availableCardSlots[handIndex] = true;
   //             Invoke("MoveToDiscardPile", 1f);

			//	if (cardDisplay.damage > 0)
			//	{
			//		demon.health = demon.health - cardDisplay.damage;
			//		Debug.Log("Monster take " + cardDisplay.damage + " damage!");
			//	}

			//	if (cardDisplay.health > 0)
			//	{
			//		player.currentHealth = player.currentHealth + cardDisplay.health;
			//		if (player.currentHealth > player.health)
			//		{
			//			player.currentHealth = player.health;
			//		}
			//	}
			//}
		}
	}

	void MoveToDiscardPile()
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		mm.discardPile.Add(this);
		gameObject.SetActive(false);
	}



}
