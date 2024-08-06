using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void  Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }    

    public void home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }    

    public void tt()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }    
}
