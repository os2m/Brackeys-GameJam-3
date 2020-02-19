using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public PlaygroundManager manager;
    public int pointsToAdd = 3;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.GetComponent<ScoreManager>().AddScore(pointsToAdd);

            int index = Random.Range(0, (manager.flags.Length -1));

            if (manager.flags[index] == gameObject)
                index++;

            if (index > manager.flags.Length - 1)
                index = 0;

            for (int i = 0; i < manager.flags.Length; i++)
            {
                if (i != index)
                    manager.flags[i].SetActive(false);
                else
                {
                    manager.flags[i].SetActive(true);
                }
            }
        }
    }
}
