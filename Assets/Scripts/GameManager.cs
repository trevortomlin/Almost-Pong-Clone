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

        PlayerPrefs.DeleteAll();

        highScoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameState == GameState.MENU)
        {

            if (Input.GetMouseButtonDown(0))
            {
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

        highScoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Score.score = 0;
        
    }
}
