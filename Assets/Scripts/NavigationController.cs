using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NavigationController : MonoBehaviour
{
    public void goGameScene()
    {
        SceneManager.LoadScene("SharkAttack");
    }
    public void goLeaderBoardScene()
    {
        SceneManager.LoadScene("LeaderBoardScene", LoadSceneMode.Additive);
    }
    public void goHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene", LoadSceneMode.Additive);
    }
    public void goCreditScene()
    {
        SceneManager.LoadScene("CreditScene", LoadSceneMode.Additive);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void GoStartMenu()
    {
        Debug.LogError("Au moins dans la fonction ma gueule");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("StartScene"));

        //if (SceneManager.GetSceneByName("StartScene").IsValid())
        //{
        
            try
            {
                SceneManager.LoadScene("StartScene");
            }
            catch (Exception e) 
            {
                Debug.LogError("AAAAAAAAAAAAAAAAAAAAAAAAA" + e.Message);
            }
        //}
        //else
        //{
          //  Debug.Log("AAAA");
        //}
            
        
    }
}
