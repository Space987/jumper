using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingLevels : MonoBehaviour
{
    public void MainMenuBtn(){
        
        GameManager.Instance.ResetAllScore();
        SceneManager.LoadScene("MenuScene");

    }

    public void RedoBtn(){

        GameManager.Instance.ResetAllScore();
        SceneManager.LoadScene("Level_1");
       
    }
}
