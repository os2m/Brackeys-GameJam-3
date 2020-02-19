using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaygroundManager : MonoBehaviour
{
    public GameObject normalPrefab;
    public GameObject badHolePrefab;
    public GameObject golfHolePrefab;
    public GameObject bunkerPrefab;
    public List<GameObject> spawner;
    [Space(10)]
    public int badHoles = 16;
    public int golfHoles = 2;
    public int bunkers = 6;
    [Space(10)]
    public Transform zRotator;
    [Space(10)]
    public GameObject golfBall;
    public Transform[] respawner;
    [Space(10)]
    public GameObject[] flags;


    // Start is called before the first frame update
    void Awake()
    {
        flags = new GameObject[golfHoles];

        GameObject[] spawnerArray = GameObject.FindGameObjectsWithTag("Spawner");
        for (int i = 0; i < spawnerArray.Length; i++)
        {
            spawner.Add(spawnerArray[i]);
        }

        for (int i = 0; i < golfHoles; i++)
        {
            int index = Random.Range(0, (spawner.Count - 1));

            GameObject golfHole = Instantiate(golfHolePrefab, spawner[index].transform.position, Quaternion.Euler(-90f, 0, 0));
            golfHole.transform.SetParent(zRotator);
            flags[i] = golfHole.GetComponentInChildren<Flag>().gameObject;
            golfHole.GetComponentInChildren<Flag>().manager = this;

            GameObject current_spawner = spawner[index];
            spawner.Remove(current_spawner);
            Destroy(current_spawner);

            if (i == golfHoles - 1)
                golfHole.GetComponentInChildren<Flag>().gameObject.SetActive(true);
            else
                golfHole.GetComponentInChildren<Flag>().gameObject.SetActive(false);

        }

        for (int i = 0; i < badHoles; i++)
        {
            int index = Random.Range(0, (spawner.Count - 1));

            GameObject badHole = Instantiate(badHolePrefab, spawner[index].transform.position, Quaternion.Euler(-90f, 0, 0));
            badHole.transform.SetParent(zRotator);

            GameObject current_spawner = spawner[index];
            spawner.Remove(current_spawner);
            Destroy(current_spawner);
        }

        for (int i = 0; i < bunkers; i++)
        {
            int index = Random.Range(0, (spawner.Count - 1));

            GameObject bunker = Instantiate(bunkerPrefab, spawner[index].transform.position, Quaternion.Euler(-90f, 0, 0));
            bunker.transform.SetParent(zRotator);

            GameObject current_spawner = spawner[index];
            spawner.Remove(current_spawner);
            Destroy(current_spawner);
        }

        for (int i = 0; i < spawner.Count; i++)
        {
            GameObject normal = Instantiate(normalPrefab, spawner[i].transform.position, Quaternion.Euler(-90f, 0, 0));
            normal.transform.SetParent(zRotator);

            spawner[i].transform.position = new Vector3(spawner[i].transform.position.x, spawner[i].transform.position.y + .6f, spawner[i].transform.position.z);
        }
    }

    void Start()
    {
        if (zRotator.GetComponent<CombineMeshes>())
            zRotator.GetComponent<CombineMeshes>().Combine();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
