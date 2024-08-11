using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu1 : MonoBehaviour
{
    public void Man1()
    {
        SceneManager.LoadScene("Level1");
    }  
    
    public void Man2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Man3()
    {
        SceneManager.LoadScene("Level3");
    }    

    public void Man4()
    {
        SceneManager.LoadScene("LevelBoss");
    }    
}
