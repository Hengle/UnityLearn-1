using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsCompontent : MonoBehaviour
{
    private Text _text;
    private void Awake()
    {
        _text = transform.Find("Content/Text").GetComponent<Text>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual void SetPosition()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="offset"></param>
    public virtual void SetPosition(Transform parent, Vector2 offset)
    {
        transform.SetParent(parent, true);
        transform.localPosition = offset;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    public virtual void SetPosition(Transform parent)
    {
        transform.SetParent(parent, true);
        transform.localPosition = Vector2.zero;
    }


    /// <summary>
    /// 设置内容
    /// </summary>
    /// <param name="content"></param>
    internal void SetContent(string content)
    {
        _text.text = content;
    }
}
