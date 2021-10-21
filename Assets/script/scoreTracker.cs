using UnityEngine;
using UnityEngine.UI;

//adapted from brackeys "How to make a HIGH SCORE in Unity"
public class scoreTracker : MonoBehaviour
{
    public int score;
    public int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void endGame()
    {
        if(score>highScore)
        {
            highScore=score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }
        Debug.Log("highscore =" + highScore);
        Debug.Log("score =" + score);
        score = 0;
    }
   
}
