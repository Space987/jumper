using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText;
    public static int  score;
    public static int tempsScore;
    public static int TotalScore;
    public static int previousLevelIndex = 0;

    

    private void Awake() {
        Instance = this;
        DontDestroyOnLoad(Instance);

        
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            scoreText.text = "Your Score is: " + tempsScore;
            score = TotalScore;
        } else {
            scoreText.text = "Score: " + score;
        }
    }

   
    public void AddScore(int _score)
    {
        score += _score;
        scoreText.text = "Score: " + score;
        tempsScore = score;
    }

    public void ResetScore(){
        score = TotalScore;
    }

    public void ResetAllScore(){
        score = 0;
        tempsScore = 0;
        TotalScore = 0;
    }

    public void saveFinalScore(){
        TotalScore = score;
    }

    public void saveSceneIndex(){
        previousLevelIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("PreviousLevelIndex", previousLevelIndex);
    }

    

    

  
}
