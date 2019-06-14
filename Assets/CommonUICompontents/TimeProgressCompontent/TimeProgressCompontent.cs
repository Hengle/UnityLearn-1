using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 时间进度UI通用组件
/// </summary>
public class TimeProgressCompontent : MonoBehaviour
{
    private Transform _parent;
    private GameObject _original;
    private RectTransform _progress;
    //总长度
    private float _width;
    private float _height;
    //tips弹窗的偏移量
    public Vector2 Offset = new Vector2(0, 25);

    public Color ColorOn;
    public Color ColorOff;

    private void Awake()
    {
        _parent = transform.Find("Content").transform;
        _original = _parent.GetChild(0).gameObject;
        _progress = transform.Find("Progress").GetComponent<RectTransform>();
        _width = transform.GetComponent<RectTransform>().rect.width;
        _height = transform.GetComponent<RectTransform>().rect.height;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="currentIndex">当前的进度下标</param>
    /// <param name="vs">tips语言文案数组</param>
    public void SetData(int currentIndex, string[] vs)
    {
        int count = vs.Length;
        if (count <= 1)
        {
            Debug.LogErrorFormat("节点数量必须大于1");
            return;
        }

        //克隆
        for (int i = 0; i < count - 1; i++)
        {
            Instantiate(_original, _parent);
        }
        Toggle[] toggles = _parent.GetComponentsInChildren<Toggle>();

        //根据进度设置进度条的长度
        float pro = currentIndex / (float)(count - 1);
        _progress.sizeDelta = new Vector2(_width * pro, _height);

        for (int i = 0; i < _parent.childCount; i++)
        {
            //设置节点的位置
            float x = (_width / (count - 1)) * i - 0.5f * _width;
            _parent.GetChild(i).transform.localPosition = new Vector3(x, 0);

            //根据进度设置节点的颜色
            bool isReach = i <= currentIndex;
            _parent.GetChild(i).transform.GetComponent<Image>().color = isReach ? ColorOn : ColorOff;
        }
        ToggleGroup toggleGroup = _parent.GetComponent<ToggleGroup>();

        for (int i = 0; i < toggles.Length; i++)
        {
            int tempIndex = i;
            toggles[tempIndex].group = toggleGroup;
            TipsCompontent tipsCompontent = toggles[tempIndex].transform.GetComponentInChildren<TipsCompontent>();
            toggles[tempIndex].onValueChanged.AddListener((isOn) =>
            {
                //如果不存在
                if (tipsCompontent == null)
                {
                    tipsCompontent = TipsFactory.Instance.GetTips(TipsSize.Small, TipsDirection.Down);
                    //弹窗位置
                    tipsCompontent.SetPosition(toggles[tempIndex].transform, Offset);
                    //弹窗内容
                    tipsCompontent.SetContent(vs[tempIndex]);
                }
                tipsCompontent.gameObject.SetActive(isOn);
            });
        }
    }

}
