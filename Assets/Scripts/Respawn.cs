using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Respawn : MonoBehaviour
{
    public PlaygroundManager manager;
    public int respawnPoints = -1;

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
        if (other.CompareTag("Respawn"))
        {
            RespawnPlayer();
        }
    }

    public void RespawnPlayer() {

        manager.GetComponent<ScoreManager>().AddScore(respawnPoints);

        int index = Random.Range(0, (manager.respawner.Length - 1));

        transform.position = manager.respawner[index].position;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<AudioSource>().Play();
    }
}
