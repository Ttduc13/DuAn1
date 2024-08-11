using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    int goldReward;
    public TextMeshProUGUI goldRewardValue;
    PlayerManager player;

    GameObject GoldButton;

    public void SetUp()
    {
        gameObject.SetActive(true);
        SetGoldReward();
        PlayerPrefs.SetInt("playerHealth", player.currentHealth);
        Debug.Log(PlayerPrefs.GetInt("playerHealth"));
    }

    public void NextButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoldReward()
    {
        player.money += goldReward;
        GoldButton.SetActive(false);
    }

    void SetGoldReward()
    {
        goldRewardValue.text = goldReward.ToString() + " Gold";
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        goldReward = Random.Range(10, 20);
        player = FindAnyObjectByType<PlayerManager>();
    }
}
