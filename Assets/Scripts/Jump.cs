using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool isFalling = true;
    public float height = 5f;
    public float maxAngularVelocity = 25f;
    private ItemManager itemManager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;

        itemManager = GameObject.FindWithTag("GameController").GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;

        if (Input.GetKeyDown(KeyCode.Space) && !isFalling && itemManager.jumps > 0)
        {
            itemManager.jumps--;
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
