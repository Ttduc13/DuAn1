using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    public void Login()
    {
        SceneManager.LoadScene("MainMenu");
    }    

    public void Exit()
    {
        Application.Quit();
    }    
}
