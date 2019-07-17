using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class XluaLoader
{
    private static LuaEnv _luaEnv;

    public static void InitXLua()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(NormalLoader);
        _luaEnv.AddLoader(ResourcesLoader);
    }

    private static byte[] ResourcesLoader(ref string fileName)
    {
#if UNITY_EDITOR
        //string path = HotFixUtility.LuaFilesDir;
        //byte[] bytes = FileUtil.Instance.GetBytesFile(path, fileName + ".lua.txt");
        //if (bytes != null)
        //{
        //    Debug.Log("<color='#987456'>XLua NormalLoader->" + fileName + "</color>   " + path);
        //    return bytes;
        //}

#else

        TextAsset ta = Resources.Load<TextAsset>(fileName + ".lua");
        if (ta != null)
        {
            Debug.Log("<color='#987456'>XLua ResourcesLoader->" + fileName + "</color>");
            return ta.bytes;
        }
#endif
        return null;
    }

    public static void LoadMainSctipt()
    {
        _luaEnv.DoString("require 'luaTest'");
    }

    private static byte[] NormalLoader(ref string fileName)
    {
        //string path = HotFixUtility.GetLuaFileFolderPath();
        //byte[] bytes = FileUtil.Instance.GetBytesFile(path, fileName + ".lua.txt");
        //if (bytes != null)
        //{
        //    Debug.Log("<color='#987456'>XLua NormalLoader->" + fileName + "</color>   " + path);
        //    bytes = AesTool.Decrypt(bytes, AesTool.DefaultPassword);
        //}
        //return bytes;

        return null;
    }
}
