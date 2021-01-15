
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    
    public GameObject hitExplosion;

    
    public  GameObject gameOverScreen;
    public GameObject scoreContainer;
    
    [HideInInspector]
    public TextMeshProUGUI scoreValue;
    [HideInInspector]
    public TextMeshProUGUI highscorevalue;

    [HideInInspector]
    public bool increaseScore= true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        scoreValue = gameOverScreen.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        highscorevalue = gameOverScreen.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public  void RestartGame()
    {
        increaseScore = true;
        scoreContainer.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public  void showGameOverScreen()
    {
        if (gameOverScreen != null && !gameOverScreen.activeInHierarchy)
        {
            gameOverScreen.SetActive(true);
            scoreContainer.SetActive(false);
            scoreValue.text = PlayerPrefs.GetInt("score").ToString();
            highscorevalue.text = PlayerPrefs.GetInt("highscore").ToString();
        }
    }
    
    
    
    
}
