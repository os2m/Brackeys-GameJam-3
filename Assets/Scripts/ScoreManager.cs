using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public TMP_Text endScoreTMP;

    public GameObject sound;
    public GameObject endPanel;

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
            endPanel.SetActive(true);
            endScoreTMP.text = "Cool, you made " + score + " points.";
                PlayerPrefs.SetInt("HS", score);
        }

        timeTMP.text = timeText;
        scoreTMP.text = "" + score;
        hScoreTMP.text = "" + highScore;
}

    public void AddScore(int toAdd)
    {
        sound.GetComponent<AudioSource>().Play();
        score += toAdd;
        if (score <= 0)
            score = 0;
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
