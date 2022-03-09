using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Player player;
    public Paddles paddles;
    public static GameManager Instance { get; private set; }

    private GameState gameState = GameState.MENU;

    public Canvas startCanvas;

    public TextMeshProUGUI highScoreText;
    
    private enum GameState {
        
        MENU,
        PLAYING

    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        PlayerPrefs.SetInt("HighScore", 0);
        highScoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {

        if (gameState == GameState.MENU)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("start game");
                startCanvas.enabled = false;
                gameState = GameState.PLAYING;
                player.ApplyStartForce();
            }

        }
    }

    public void Reset()
    {
        player.Reset();
        paddles.Reset();
        startCanvas.enabled = true;
        gameState = GameState.MENU;
        Score.score = 0;
        highScoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore");
    }
}
