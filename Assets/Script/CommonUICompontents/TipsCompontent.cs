using System;
using UnityEngine;
using UnityEngine.UI;

public class TipsCompontent : MonoBehaviour
{
    private Text _text;
    private Button _buttonClose;
    private TipsConfig _tipsConfig;
    private void Awake()
    {
        _text = transform.Find("Content/Text").GetComponent<Text>();
        _buttonClose = transform.Find("ButtonClose").GetComponent<Button>();
        _buttonClose.onClick.AddListener(OnButtonClose);
    }

    private void OnButtonClose()
    {
        gameObject.Hide();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="offset"></param>
    public void SetParent(Transform parent)
    {
        transform.SetParent(parent, true);
        transform.localScale = Vector3.one * _tipsConfig.LocalScale;
        transform.localPosition = _tipsConfig.Offset;
    }
    /// <summary>
    /// 设置tips的样式
    /// </summary>
    /// <param name="localScale"></param>
    /// <param name="fontSize"></param>
    public void SetStyle(TipsConfig tipsConfig)
    {
        _tipsConfig = tipsConfig;
        _text.fontSize = _tipsConfig.FontSize;
        _buttonClose.gameObject.SetActive(_tipsConfig.IsCloseAnyKey);
        if (_tipsConfig.Parent != null)
        {
            SetParent(_tipsConfig.Parent);
        }
        else
        {
            transform.localScale = Vector3.one * _tipsConfig.LocalScale;
            transform.localPosition = _tipsConfig.Offset;
        }
        if (!string.IsNullOrEmpty(_tipsConfig.Content))
        {
            SetContent(_tipsConfig.Content);
        }

    }
    /// <summary>
    /// 设置内容
    /// </summary>
    /// <param name="content"></param>
    public void SetContent(string content)
    {
        _text.text = content;
    }

}
