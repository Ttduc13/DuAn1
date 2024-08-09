using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameState State;
	public static event Action<GameState> OnGameStateChanged;

	public bool isPlayerTurn = true;

	Enemy enemy;

	public MenuManager menuManager;

	PlayerManager player;

	public GameObject EnemyTurn;
	public GameObject PlayerTurn;

	public GameOver gameOver;
	public EndScene endScene;

	public AudioManager audioManager;

    private void Awake()
    {
        instance = this;
    }

	public void UpdateGameState(GameState newState)
	{
		State = newState;

		switch (newState)
		{
			case GameState.PlayerTurn:
				HandlePlayerTurn();
                break;
			case GameState.EnemyTurn:
				HandleEnemyTurn();
                break;
			case GameState.Victory:
				HandleVictory();
				break;
            case GameState.Lose:
                HandleLose();
                break;
			case GameState.NextLevel:
				HandleNexlLevel();
                break;
			case GameState.EndGame:
				HandleEndGame();
                break;
			default:
				throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

		OnGameStateChanged?.Invoke(newState);
    }

	public async void HandlePlayerTurn()
	{		
        
		enemy.CheckVulnerableCount();
        enemy.randomEvents();
		audioManager.PlaySFX(audioManager.playerTurn);
        PlayerTurn.SetActive(true);
        isPlayerTurn = true;
		player.shield = 0;
        menuManager.StartTurn();
		menuManager.AutoShuffle();
        Debug.Log("Player Turn");
		player.currentMana = player.mana;
		player.updateManaValue();
        await Task.Delay(900);
        PlayerTurn.SetActive(false);
    }

	public async void HandleEnemyTurn()
	{
		EnemyTurn.SetActive(true);
		isPlayerTurn = false;
		Debug.Log("Enemy Turn");
		audioManager.PlaySFX(audioManager.enemyTurn);

		await Task.Delay(900);
		EnemyTurn.SetActive(false);
        enemy.DamagePlayer();
        await Task.Delay(3000);
        UpdateGameState(GameState.PlayerTurn);
    }

	public async void HandleVictory()
	{
		Debug.Log("Win!");
        UpdateGameState(GameState.NextLevel);
        await Task.Delay(100);
    }

    public async void HandleLose()
    {
        Debug.Log("Lose!");
        UpdateGameState(GameState.EndGame);
        await Task.Delay(100);
    }

	public void HandleNexlLevel()
	{
        endScene.SetUp();
    }

	public void HandleEndGame()
	{
        gameOver.Setup();
    }

    private void Start()
	{
		//menuManager = FindObjectOfType<MenuManager>();
		player = FindObjectOfType<PlayerManager>();
        enemy = FindObjectOfType<Enemy>();
		//gameOver = FindObjectOfType<GameOver>();

        UpdateGameState(GameState.PlayerTurn);
    }
}

public enum GameState
{
	PlayerTurn,
	EnemyTurn,
	Victory,
	Lose,
	NextLevel,
	EndGame,
}


