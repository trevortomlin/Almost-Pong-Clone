using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score;
    void Start()
    {

        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<TextMeshProUGUI>().text = score.ToString();

    }

}
