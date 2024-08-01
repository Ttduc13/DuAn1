using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;
using static Unity.Burst.Intrinsics.Arm;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public GameState State;
	public static event Action<GameState> OnGameStateChanged;

	public bool isPlayerTurn = false;

	Demon demon;

	MenuManager menuManager;

	PlayerManager player;

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

	public void HandlePlayerTurn()
	{
        isPlayerTurn = true;
		Debug.Log("Player Turn");
		player.currentMana = player.mana;
	}

	public async void HandleEnemyTurn()
	{
        isPlayerTurn = false;
        Debug.Log("Enemy Turn");
        demon = FindObjectOfType<Demon>();

		demon.DamagePlayer();
        await Task.Delay(1000);

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
