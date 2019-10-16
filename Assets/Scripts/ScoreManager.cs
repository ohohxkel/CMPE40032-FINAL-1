using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.

    Text text, highScoreText;                   // Reference to the Text component.

    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();

        // Reset the score.
        score = 0;
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = score.ToString();

        if(PlayerPrefs.GetInt("HighScore")<= score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}