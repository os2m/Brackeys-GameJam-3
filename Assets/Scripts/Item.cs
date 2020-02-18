﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemManager itemManager;
    public string coroutine = "CameraItem";

    // Start is called before the first frame update
    void Start()
    {
        itemManager = GameObject.FindWithTag("GameController").GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemManager.StartCoroutine(coroutine);
            Destroy(gameObject);
        }
    }
}