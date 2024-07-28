using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public List<Card> deck;
    public TextMeshProUGUI deckSizeText;

    public Transform[] cardSlots;
    public bool[] availableCardSlots;

    public List<Card> discardPile;
    public TextMeshProUGUI discardPileSizeText;

    Demon demon;
    public TextMeshProUGUI demonHealth;

    PlayerManager player;
    public TextMeshProUGUI playerHealth;

    private Animator camAnim;

    GameManager gameManager;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        //throw new NotImplementedException();
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        camAnim = Camera.main.GetComponent<Animator>();
        demon = FindObjectOfType<Demon>();
        player=FindObjectOfType<PlayerManager>();
    }

    public void DrawCard()
    {
        if(gameManager.isPlayerTurn == true)
        {
            if (deck.Count >= 1)
            {
                camAnim.SetTrigger("shake");

                Card randomCard = deck[UnityEngine.Random.Range(0, deck.Count)];
                for (int i = 0; i < availableCardSlots.Length; i++)
                {
                    if (availableCardSlots[i] == true)
                    {
                        randomCard.gameObject.SetActive(true);
                        randomCard.handIndex = i;
                        randomCard.transform.position = cardSlots[i].position;
                        randomCard.hasBeenPlayed = false;
                        deck.Remove(randomCard);
                        availableCardSlots[i] = false;
                        return;
                    }
                }
            }
        }
        
    }

    public void Shuffle()
    {
        if(gameManager.isPlayerTurn == true)
        {
            if (discardPile.Count >= 1)
                {
                    foreach (Card card in discardPile)
                    {
                        deck.Add(card);
                    }
                    discardPile.Clear();
                }
        }
    }

    public void EndTurn()
    {
        if (gameManager.isPlayerTurn == true)
        {
            GameManager.instance.UpdateGameState(GameState.EnemyTurn);
        }
    }

    void Update()
    {
        deckSizeText.text = deck.Count.ToString();
        discardPileSizeText.text = discardPile.Count.ToString();

        demonHealth.text = demon.health.ToString();
        playerHealth.text = player.health.ToString();
    }
}
