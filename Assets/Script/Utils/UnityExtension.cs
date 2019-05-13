using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityExtension : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Color color = Color16ToRGBA("#636D85FF");


        Debug.Log(color.r * 255 + "_" + color.g * 255 + "_" + color.b * 255);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public static string ColorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
        return hex;
    }


    /// <summary>
    /// 16进制颜色码转化为RGBA颜色值
    /// </summary>
    /// <param name="htmlString">#CC00FF</param>
    /// <returns>（204,0,255,255）</returns>
    public static Color Color16ToRGBA(string htmlString)
    {
        if (!htmlString.Contains("#"))
        {
            Debug.LogError(">>>输入有误！");
        }

        Color color;
        ColorUtility.TryParseHtmlString(htmlString, out color);
        return color;
    }
}
