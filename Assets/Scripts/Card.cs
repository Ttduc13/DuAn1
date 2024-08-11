using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
	Enemy enemy;

	CardDisplay cardDisplay;
	CardFunction cardFunction;

	public AudioManager audioManager;

    public Transform skillPos;
    public GameObject[] prefab;
    public int index;

    private void Start()
	{
		mm = FindObjectOfType<MenuManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();

		demon = FindObjectOfType<Enemy>();
        player = FindObjectOfType<PlayerManager>();
		enemy = FindObjectOfType<Enemy>();

        cardDisplay = GetComponent<CardDisplay>();
		cardFunction = GetComponent<CardFunction>();

		audioManager = FindAnyObjectByType<AudioManager>();
    }
	private void OnMouseDown()
	{
		if (gameManager.isPlayerTurn == true)
		{
			if (player.currentMana > 0 && cardFunction.manaCost <= player.currentMana)
			{
                if (!hasBeenPlayed)
                {
                    audioManager.PlaySFX(audioManager.cardSelect);

                    Instantiate(hollowCircle, transform.position, Quaternion.identity);

                    camAnim.SetTrigger("shake");
                    anim.SetTrigger("move");

                    transform.position += Vector3.up * 3f;
                    hasBeenPlayed = true;
                    mm.availableCardSlots[handIndex] = true;
                    Invoke("MoveToDiscardPile", 1f);

					cardFunction.Attack();
					cardFunction.Defend();

					if (enemy.vulnerableCount > 0) 
					{
                        cardFunction.Attack();
						Debug.Log("Hit 2 times!");
                    }
                    cardFunction.EffectCard();

                    player.currentMana = player.currentMana - cardFunction.manaCost;
					player.updateManaValue();
                }
            }
		}
	}

	void MoveToDiscardPile()
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		mm.discardPile.Add(this);
		gameObject.SetActive(false);
        Instantiate(prefab[index], skillPos.position, Quaternion.identity);
    }

    void Update()
    {
        index = UnityEngine.Random.Range(0, 2);
    }
}
