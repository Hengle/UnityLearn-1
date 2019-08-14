using System.Collections.Generic;
using UnityEngine;

public class LanguageService : MonoBehaviour
{
    public static LanguageService Instance { get; private set; }

    private Dictionary<Module, Dictionary<string, string>> _languageDict;

    private readonly string BASTEPATH = "Language/";

    private void Awake()
    {
        Instance = this;
        _languageDict = new Dictionary<Module, Dictionary<string, string>>();
    }

    private void OnDestroy()
    {
        Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="module"></param>
    /// <returns></returns>
    public string GetString(Module module, string key)
    {
        if (!_languageDict.ContainsKey(module))
        {
            LoadLanguage(module);
        }

        if (!_languageDict[module].ContainsKey(key))
        {
            Debug.LogError("不存在 module：" + module + " key:" + key);
            return string.Empty;
        }

        return _languageDict[module][key];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="module">模块名</param>
    /// <param name="objs">参数列表</param>
    /// <returns></returns>
    public string GetStringFormat(Module module, string key, params object[] objs)
    {
        string format = GetString(module, key);
        return string.Format(format, objs);
    }

    /// <summary>
    /// 添加语言文案
    /// </summary>
    /// <param name="module">模块</param>
    private void LoadLanguage(Module module)
    {
        string path = BASTEPATH + module + "/" + Config.Language;
        TextAsset textAsset = AssetsService.Instance.LoadAsset<TextAsset>(path);
        if (textAsset == null)
        {
            Debug.LogError("确实语言配置文件:" + path);
            return;
        }
        LanguageList languageList = JsonUtility.FromJson<LanguageList>(textAsset.ToString());

        Dictionary<string, string> dict = new Dictionary<string, string>();
        for (int i = 0; i < languageList.languages.Count; i++)
        {
            string key = languageList.languages[i].key;
            string value = languageList.languages[i].value;
            dict.Add(key, value);
        }
        _languageDict.Add(module, dict);
    }

    public void Clear()
    {
        _languageDict.Clear();
    }
}