using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreenScript : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScoreManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
