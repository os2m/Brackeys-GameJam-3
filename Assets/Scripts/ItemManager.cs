using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [Header("Cam")]
    public Image camButton;
    public Sprite camBtnNormal;
    public Sprite camBtnHightlighted;
    public Camera cam;
    public float camDuration = 5f;
    public Transform normalPos;
    public Transform funnyPos;
    [Header("Arrow")]
    public Shake shake;
    public float noShakeDuration = 10f;
    public Image arrowButton;
    public Sprite arrowBtnNormal;
    public Sprite arrowBtnHightlighted;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ArrowItem()
    {
        arrowButton.sprite = arrowBtnHightlighted;

        shake.enabled = false;
        yield return new WaitForSeconds(noShakeDuration);
        shake.enabled = true;

        arrowButton.sprite = arrowBtnNormal;

    }

    public IEnumerator CameraItem()
    {
        camButton.sprite = camBtnHightlighted;

        cam.transform.position = funnyPos.position;
        cam.transform.rotation = funnyPos.rotation;
        yield return new WaitForSeconds(camDuration);
        cam.transform.position = normalPos.position;
        cam.transform.rotation = normalPos.rotation;

        camButton.sprite = camBtnNormal;
    }
}
