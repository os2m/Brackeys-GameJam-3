using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int highScore;
    public int score;

    public float minutes = 10f;
    public string timeText;
    public float CurrentTime;
    public float Minutes { get { return Mathf.Floor(CurrentTime / 60f); } }
    public float Seconds { get { return Mathf.Floor(CurrentTime % 60f); } }

    public TMP_Text timeTMP;
    public TMP_Text scoreTMP;
    public TMP_Text hScoreTMP;


    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HS");

        CurrentTime = minutes * 60f;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= Time.deltaTime;
        timeText = Minutes + " : " + Seconds;

        if (CurrentTime <= 0)
        {
            timeText = "NICE JOB";
            if (score > highScore)
                PlayerPrefs.SetInt("HS", score);
        }

        timeTMP.text = timeText;
        scoreTMP.text = "" + score;
        hScoreTMP.text = "" + highScore;
}

    public void AddScore(int toAdd)
    {
        score += toAdd;
        if (score <= 0)
            score = 0;
    }
}
