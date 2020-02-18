using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public PlaygroundManager manager;

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
            int index = Random.Range(0, (manager.respawner.Length - 1));

            transform.position = manager.respawner[index].position;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

    }
}
