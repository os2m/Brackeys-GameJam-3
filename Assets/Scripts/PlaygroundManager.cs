using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundManager : MonoBehaviour
{
    public GameObject normalPrefab;
    public GameObject badHolePrefab;
    public GameObject golfHolePrefab;
    public List<GameObject> spawner;
    [Space(10)]
    public int badHoles = 16;
    public int golfHoles = 2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnerArray = GameObject.FindGameObjectsWithTag("Spawner");
        for (int i = 0; i < spawnerArray.Length; i++)
        {
            spawner.Add(spawnerArray[i]);
        }

        for (int i = 0; i < badHoles; i++)
        {
            int index = Random.Range(0, (spawner.Count - 1));

            GameObject badHole = Instantiate(badHolePrefab, spawner[index].transform.position, Quaternion.Euler(-90f, 0, 0));
            badHole.transform.SetParent(spawner[index].transform);

            spawner.Remove(spawner[index]);
        }

        for (int i = 0; i < golfHoles; i++)
        {
            int index = Random.Range(0, (spawner.Count - 1));

            GameObject golfHole = Instantiate(golfHolePrefab, spawner[index].transform.position, Quaternion.Euler(-90f, 0, 0));
            golfHole.transform.SetParent(spawner[index].transform);

            spawner.Remove(spawner[index]);
        }

        for (int i = 0; i < spawner.Count; i++)
        {
            GameObject normal = Instantiate(normalPrefab, spawner[i].transform.position, Quaternion.Euler(-90f, 0, 0));
            normal.transform.SetParent(spawner[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
