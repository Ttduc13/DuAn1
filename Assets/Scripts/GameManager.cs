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

	public bool isPlayerTurn = false;

	Enemy enemy;

	MenuManager menuManager;

	PlayerManager player;

	public GameObject EnemyTurn;
	public GameObject PlayerTurn;

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
				break;
            case GameState.Lose:
                break;
			default:
				throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

		OnGameStateChanged?.Invoke(newState);
    }

	public async void HandlePlayerTurn()
	{
        enemy = FindObjectOfType<Enemy>();
        enemy.randomEvents();
        PlayerTurn.SetActive(true);
        isPlayerTurn = true;
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
        enemy = FindObjectOfType<Enemy>();
		await Task.Delay(900);
		EnemyTurn.SetActive(false);
        enemy.DamagePlayer();
        await Task.Delay(3000);

        UpdateGameState(GameState.PlayerTurn);

    }

    private void Start()
	{
		menuManager = FindObjectOfType<MenuManager>();
		player = FindObjectOfType<PlayerManager>();
        UpdateGameState(GameState.PlayerTurn);
        
    }

}

public enum GameState
{
	PlayerTurn,
	EnemyTurn,
	Victory,
	Lose,
}
