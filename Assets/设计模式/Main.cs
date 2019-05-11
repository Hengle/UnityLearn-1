﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Factory factory = new Factory();
        Fish sharkFish = factory.GetFish("sharkFish");
        sharkFish.Swim();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
