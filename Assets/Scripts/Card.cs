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
	Demon demon;

    private void Start()
	{
		mm = FindObjectOfType<MenuManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();

		demon = FindObjectOfType<Demon>();
    }
	private void OnMouseDown()
	{
		if (gameManager.isPlayerTurn == true)
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

				demon.health = demon.health - 1;
                Debug.Log("Monster take " + 1 + " damage!");
            }
        }
	}

	void MoveToDiscardPile()
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		mm.discardPile.Add(this);
		gameObject.SetActive(false);
	}



}
