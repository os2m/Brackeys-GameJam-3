using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HightlightOnKey : MonoBehaviour
{
    public KeyCode key;
    public Sprite normal;
    public Sprite hightlighted;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
            image.sprite = hightlighted;
        else
            image.sprite = normal;
    }
}
