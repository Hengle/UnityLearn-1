using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab1 : MonoBehaviour
{
    public static Lab1 Instance { get; private set; }

    public int Num = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void Func()
    {
        Debug.LogError("Func");
    }

    public void Func1(string value)
    {
        Debug.LogError("Func1:" + value);
    }
}
