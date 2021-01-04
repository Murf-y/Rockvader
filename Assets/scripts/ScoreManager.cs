using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI _text;

    private int score;
    private int Highscore;
    
    void Start()
    {
        Highscore = PlayerPrefs.GetInt("highscore");
        
        PlayerPrefs.SetInt("highscore", Highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.increaseScore)
        {
            score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
            PlayerPrefs.SetInt("score", score);
            _text.text =score.ToString();
        }

        if (score > Highscore)
        {
            PlayerPrefs.SetInt("highscore",score);
            Highscore = PlayerPrefs.GetInt("highscore");
        }
       
        
        
    }
}
