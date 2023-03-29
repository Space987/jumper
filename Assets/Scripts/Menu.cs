using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("Level_1");
    }

    public void quitGame(){
        // Lets me know that the game will quit
        Debug.Log("The Game Will Quit Soon!");
        #if UNITY_EDITOR
        // When it is in editor mode
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        // If i actual lauch the game irl
        Application.Quit();
    }
}
