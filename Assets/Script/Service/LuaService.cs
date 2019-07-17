using System.IO;
using System.Text;
using UnityEngine;
using XLua;
[Hotfix]
public class LuaService : MonoBehaviour
{
    private LuaEnv _luaEnv;
    public static LuaService Instance;

    private void Start()
    {
        _luaEnv = new LuaEnv();
        _luaEnv.AddLoader(MyLoader);
        _luaEnv.DoString("require 'LuaScript'");
    }

    private void OnDisable()
    {
        _luaEnv.DoString("require 'LuaDispose'");
    }

    private void OnDestroy()
    {
        _luaEnv.Dispose();
    }

    private byte[] MyLoader(ref string fileName)
    {
        string path = Application.dataPath + "/LuaScript/" + fileName + ".lua";

        if (File.Exists(path))
        {
            return Encoding.UTF8.GetBytes(File.ReadAllText(path));
        }
        return null;
    }
}
