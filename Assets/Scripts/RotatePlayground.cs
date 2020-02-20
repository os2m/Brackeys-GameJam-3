using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayground : MonoBehaviour
{
    public float rotationSpeed = 0.4f;
    public Transform zRotator;
    public float maxRotation = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        if (!zRotator)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreManager>().CurrentTime > 0)
        {
            if ((transform.rotation.x <= maxRotation && transform.rotation.x >= -maxRotation)
            || (transform.rotation.x >= maxRotation && Input.GetAxis("Vertical") < 0)
            || (transform.rotation.x <= -maxRotation && Input.GetAxis("Vertical") > 0))
                transform.Rotate(new Vector3(Input.GetAxis("Vertical") * rotationSpeed, 0, 0));

            if ((zRotator.rotation.z >= -maxRotation && zRotator.rotation.z <= maxRotation)
                || (zRotator.rotation.z >= maxRotation && Input.GetAxis("Horizontal") > 0)
                || (zRotator.rotation.z <= -maxRotation && Input.GetAxis("Horizontal") < 0))
                zRotator.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed));

        }
    }
}
