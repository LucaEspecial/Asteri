﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvInstance : MonoBehaviour
{
    public static InvInstance Instance { get; private set; }
     private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
