using System;
using UnityEngine;

public class Lab : MonoBehaviour
{
    private void Awake()
    {

        Item current;

        Debug.Log(Math.Pow(10, 2));

    }


    class Item
    {

    }

    [ContextMenu("Play")]
    private void Play()
    {
        Debug.Log("do lua ");
        // do lua
    }

    private void Func()
    {
        Debug.Log("this message is form CSharp....");
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            LuaService.Instance.LoadLuaScript();
            Play();
        }
    }
}
