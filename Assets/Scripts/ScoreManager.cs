using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    static public int score;




    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        ChangeScore(0);


    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "X" + score.ToString();
    }
}
