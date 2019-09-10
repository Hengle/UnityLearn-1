using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityUtility
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

    /// <summary>
    /// 随机打乱List顺序
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    private static List<T> BreakSortList<T>(List<T> list)
    {
        var random = new System.Random();
        var newList = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            newList.Insert(random.Next(newList.Count + 1), list[i]);
        }
        return newList;
    }

    /// <summary>
    /// 返回UI在Canvas的绝对坐标
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static Vector2 GetUIPosRelativeCanvas(Canvas canvas, Transform transform)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, transform.position, canvas.GetComponent<Camera>(), out Vector2 pos))
        {
            return pos;
        }
        return pos;
    }
}
