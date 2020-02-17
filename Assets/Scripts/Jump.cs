using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool isFalling = true;
    public float height = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling){
            GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, height, GetComponent<Rigidbody>().velocity.z);
        }

        isFalling = true;
    }

    void OnCollisionStay(Collision collision)
    {
        //we are on something
        isFalling = false;
    }
}
