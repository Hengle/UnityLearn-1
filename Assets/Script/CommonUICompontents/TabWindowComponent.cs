using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void TabDelegate(int index);

public class TabWindowComponent : MonoBehaviour
{
    public int FontSizeOn = 36;
    public int FontSizeOff = 30;
    public int FontSizeOnSub = 26;
    public int FontSizeOffSub = 24;
    public Color ColorOn;
    public Color ColorOff;

    private GameObject _toggleItemOriginal;
    private Transform _toggleItemParent;
    private ToggleGroup _toggleGroup;

    //当前选中的下标
    private int _currentIndex = -1;
    private void Awake()
    {
        _toggleItemParent = transform.Find("TabBg/Toggles").transform;
        _toggleItemOriginal = _toggleItemParent.GetChild(0).gameObject;
        _toggleGroup = _toggleItemParent.GetComponent<ToggleGroup>();
    }


    public void SetData(Transform parent, List<string> tabNameList, List<string> tabSubNameList, TabDelegate tabDelegate, int defaultIndex = 0)
    {
        //克隆 toggle Item
        for (int i = 0; i < tabNameList.Count - 1; i++)
        {
            Instantiate(_toggleItemOriginal, _toggleItemParent);
        }
        Toggle[] toggles = _toggleItemParent.GetComponentsInChildren<Toggle>();
        transform.Find("TabBg/Decorate").gameObject.SetActive(toggles.Length <= 3);


        for (int i = 0; i < toggles.Length; i++)
        {
            int tempIndex = i;
            Text lable = toggles[tempIndex].transform.Find("Label").GetComponent<Text>();
            lable.text = tabNameList[tempIndex];
            GameObject effect = toggles[tempIndex].transform.Find("TabEffect").gameObject;
            toggles[tempIndex].group = _toggleGroup;
            toggles[tempIndex].onValueChanged.AddListener((isOn) =>
            {
                if (isOn && (_currentIndex != tempIndex))
                {
                    _currentIndex = tempIndex;
                    tabDelegate(tempIndex);
                }
                lable.color = isOn ? ColorOn : ColorOff;
                lable.fontSize = isOn ? FontSizeOn : FontSizeOff;
                effect.SetActive(isOn);
                toggles[tempIndex].transform.Find("LineLight").gameObject.SetActive(!isOn);
                if (tempIndex != 0)
                {
                    toggles[tempIndex - 1].transform.Find("LineLight").gameObject.SetActive(!isOn);
                }
            });
        }
        toggles[defaultIndex].isOn = true;
    }
}

