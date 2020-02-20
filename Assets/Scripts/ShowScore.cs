using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Your high score is: " + PlayerPrefs.GetInt("HS");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
