using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void TabDelegate(int index);

public class TabWindowComponent : MonoBehaviour
{
    public int FontSizeOn = 36;
    public int FontSizeOff = 30;
    public Color ColorOn;
    public Color ColorOff;

    private GameObject _toggleItemOriginal;
    private Transform _toggleItemParent;
    private ToggleGroup _toggleGroup;


    //当前选中的下标
    private int _currentIndex = -1;

    private void Awake()
    {
        _toggleItemParent = transform.Find("Toggles").transform;
        _toggleItemOriginal = _toggleItemParent.GetChild(0).gameObject;
        _toggleGroup = _toggleItemParent.GetComponent<ToggleGroup>();
    }


    public void SetData(Transform parent, string[] tabs, TabDelegate tabDelegate, int defaultIndex = 0)
    {
        //克隆 toggle Item
        for (int i = 0; i < tabs.Length - 1; i++)
        {
            Instantiate(_toggleItemOriginal, _toggleItemParent);
        }
        Toggle[] toggles = _toggleItemParent.GetComponentsInChildren<Toggle>();

        for (int i = 0; i < toggles.Length; i++)
        {
            int tempIndex = i;
            Text lable = toggles[tempIndex].transform.GetComponentInChildren<Text>();
            lable.text = tabs[tempIndex];
            toggles[tempIndex].group = _toggleGroup;
            toggles[tempIndex].onValueChanged.AddListener((isOn) =>
            {
                if (_currentIndex != tempIndex)
                {
                    if (isOn)
                    {
                        _currentIndex = tempIndex;
                        tabDelegate(tempIndex);
                    }
                    lable.color = isOn ? ColorOn : ColorOff;
                    lable.fontSize = isOn ? FontSizeOn : FontSizeOff;
                }
            });
        }
        toggles[defaultIndex].isOn = true;
    }
}

