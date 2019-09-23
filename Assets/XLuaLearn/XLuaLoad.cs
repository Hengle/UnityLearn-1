using UnityEngine;

public class XLuaLoad : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //重新load
            LuaService.Instance.LoadLuaScript();
            Play();
            Play1();
        }
    }

    private void Play()
    {
        Debug.Log("do lua ");
        // do lua
    }

    private void Play1()
    {
        Debug.Log("do lua ");
        // do lua
    }

    private void Func()
    {
        Debug.LogError("this message is from Chsharp");
    }
}
