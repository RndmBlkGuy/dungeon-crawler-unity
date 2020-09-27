using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;
    public ArrayList keys;

    public void Awake()
    {
        gm = this;
        keys = new ArrayList();

    }

    void Start()
    {

    }

    void addKey(String key)
    {
        keys.Add(key);
    }

    
}
