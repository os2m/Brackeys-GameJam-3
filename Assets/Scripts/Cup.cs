using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cup : MonoBehaviour
{
    public int minScore = 100;
    public Material black;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("HS") < minScore)
            GetComponent<Renderer>().material = black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
