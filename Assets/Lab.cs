using System;
using UnityEngine;
using UnityEditor;
public class Lab : MonoBehaviour
{
    private void Awake()
    {
        MsgBase msgBase = new MsgBase(3003);
        Debug.Log(msgBase.GetManagerId().ToString());
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
