using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        string str = LanguageService.Instance.GetString(Module.Common, "yes");
        Debug.Log(str);
    }
}
