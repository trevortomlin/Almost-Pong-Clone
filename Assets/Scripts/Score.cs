using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI scoreText;
    void Start()
    {

        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = score.ToString();

    }

    public void Reset()
    {
        score = 0;
    }

}
