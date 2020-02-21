using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseGame()
    {
        if (Time.timeScale > 0.1)
            Time.timeScale = 0.0000001f;
        else
            Time.timeScale = 1.1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }
}
