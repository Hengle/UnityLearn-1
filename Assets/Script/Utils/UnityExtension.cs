using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityExtension
{
    /// <summary>
    /// 16进制颜色码转化为RGBA颜色值
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string RGBAToHtmlString(Color color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
        return hex;
    }


    /// <summary>
    /// 16进制颜色码转化为RGBA颜色值
    /// </summary>
    /// <param name="htmlString">#CC00FF</param>
    /// <returns>（204,0,255,255）</returns>
    public static Color HtmlStringToRGBA(string htmlString)
    {
        if (!htmlString.Contains("#"))
        {
            Debug.LogError(">>>输入有误！");
        }

        Color color;
        ColorUtility.TryParseHtmlString(htmlString, out color);
        return color;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Transform FindInChild(this Transform transform, string name)
    {
        Transform[] transforms = transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < transforms.Length; i++)
        {
            if (transforms[i].name.Equals(name))
            {
                return transforms[i];
            }
        }

        return null;
    }
}
