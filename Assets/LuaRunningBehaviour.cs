using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
//https://www.2cto.com/kf/201701/591817.html

[LuaCallCSharp]
public class LuaRunningBehaviour : MonoBehaviour
{
    public TextAsset _luaScript;

    private static LuaEnv _luaEnv = new LuaEnv();

    private LuaTable _scriptEnv;
    void Start()
    {
        _scriptEnv = _luaEnv.NewTable();

        LuaTable meta = _luaEnv.NewTable();
        meta.Set("_index", _luaEnv.Global);
        _scriptEnv.SetMetaTable(meta);
        meta.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
