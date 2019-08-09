using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 时间进度UI通用组件
/// </summary>
public class TimeProgressCompontent : MonoBehaviour
{
    public Color ColorOn;
    public Color ColorOff;
    public Color ColorSelect;

    private Transform _parent;
    private GameObject _original;
    private Transform _labelParent;
    private GameObject _labelOriginal;
    private RectTransform _progress;
    //总长度
    private float _width;
    private float _height;
    private Toggle[] _toggles;
    private int _count;
    private List<long> _timeStampList;

    //是否需要显示tips
    private bool _hasTips = true;
    //当前的选中的下标
    private int _currentIndex;
    //默认的Tips样式
    private TipsConfig _tipsConfig;
    private List<string> _tipsList;
    private Text[] _labels;
    private bool _hasInit = false;

    private void Init()
    {
        _parent = transform.Find("Content").transform;
        _original = _parent.GetChild(0).gameObject;
        _labelParent = transform.Find("LabelContent").transform;
        _labelOriginal = _labelParent.GetChild(0).gameObject;
        _progress = transform.Find("Progress").GetComponent<RectTransform>();
        _width = transform.GetComponent<RectTransform>().rect.width;
        _height = transform.GetComponent<RectTransform>().rect.height;
        _hasInit = true;
    }
    /// <summary>
    /// 设置数量
    /// </summary>
    /// <param name="count"></param>
    private void SetCount(int count)
    {
        if (count <= 1)
        {
            Debug.LogErrorFormat("节点数量必须大于1");
            return;
        }
        _count = count;
        //初始化
        if (!_hasInit)
        {
            Init();
        }
        //克隆
        for (int i = 0; i < _count - 1; i++)
        {
            Instantiate(_original, _parent);
        }
        //添加toggle的监听事件
        _toggles = _parent.GetComponentsInChildren<Toggle>();
        ToggleGroup toggleGroup = _parent.GetComponent<ToggleGroup>();
        for (int i = 0; i < _count; i++)
        {
            int tempIndex = i;
            _toggles[tempIndex].group = toggleGroup;
            TipsCompontent tipsCompontent = _toggles[tempIndex].transform.GetComponentInChildren<TipsCompontent>();
            _toggles[tempIndex].onValueChanged.AddListener((isOn) =>
            {
                if (_tipsList != null && _hasTips)
                {
                    //如果不存在
                    if (tipsCompontent == null)
                    {
                        tipsCompontent = TipsFactory.Instance.GetTips(_tipsConfig);
                        //弹窗位置
                        tipsCompontent.SetParent(_toggles[tempIndex].transform);
                        //弹窗内容
                        tipsCompontent.SetContent(_tipsList[tempIndex]);
                    }
                    tipsCompontent.gameObject.SetActive(isOn);
                }
            });
        }
    }
    /// <summary>
    /// 设置当前出于哪一个节点
    /// </summary>
    /// <param name="index"></param>
    private void SetOn(int index)
    {
        if (_toggles.Length <= index)
        {
            Debug.LogError("index太大");
            return;
        }
        _toggles[_currentIndex].transform.Find("Background/BigPoint").gameObject.Hide();
        _currentIndex = index;
        //根据进度设置进度条的长度
        float pro = _currentIndex / (float)(_count - 1);
        _progress.sizeDelta = new Vector2(_width * pro, _height);
        for (int i = 0; i < _parent.childCount; i++)
        {
            //设置节点的位置
            float x = (_width / (_count - 1)) * i - 0.5f * _width;
            _parent.GetChild(i).transform.localPosition = new Vector3(x, 0);

            //根据进度设置节点的颜色
            bool isReach = i < _currentIndex;
            _parent.GetChild(i).transform.Find("Background").GetComponent<Image>().color = isReach ? ColorOn : ColorOff;
            _parent.GetChild(_currentIndex).transform.Find("Background").GetComponent<Image>().color = ColorSelect;
        }
        _toggles[_currentIndex].isOn = true;
        _toggles[_currentIndex].transform.Find("Background/BigPoint").gameObject.Show();
    }
    /// <summary>
    /// 显示是否要显示Tips
    /// </summary>
    /// <param name="hasTips"></param>
    private void SetTipsState(bool hasTips)
    {
        if (_tipsList == null)
        {
            Debug.Log("需先设置_tipsList");
            return;
        }
        _hasTips = hasTips;

        for (int i = 0; i < _toggles.Length; i++)
        {
            if (_toggles[i].isOn)
            {
                _toggles[i].isOn = false;
                break;
            }
        }
        _toggles[_currentIndex].isOn = true;
    }
    /// <summary>
    /// 设置Tips的文案列表
    /// </summary>
    /// <param name="tipsList"></param>
    private void SetTipsList(List<string> tipsList)
    {
        if (tipsList.Count != _count)
        {
            Debug.LogError("设置Tips列表数量有误");
            return;
        }
        _tipsList = tipsList;
    }
    /// <summary>
    /// 设置Tips的样式
    /// </summary>
    /// <param name="tipsConfig"></param>
    private void SetTipsStyle(TipsConfig tipsConfig)
    {
        _tipsConfig = tipsConfig;
    }
    /// <summary>
    /// 设置标签文案列表
    /// </summary>
    private void SetLabelList(Dictionary<int, string> labelDict)
    {
        if (_toggles == null)
        {
            Debug.LogError("先初始化 SetCount");
            return;

        }
        for (int i = 0; i < labelDict.Count - 1; i++)
        {
            Instantiate(_labelOriginal, _labelParent);
        }
        _labels = _labelParent.GetComponentsInChildren<Text>();

        int index = 0;
        var enumerator = labelDict.GetEnumerator();
        while (enumerator.MoveNext())
        {
            int key = enumerator.Current.Key;
            _labels[index].text = labelDict[key];
            //设置坐标
            float x = (_toggles[key].transform.localPosition.x + _toggles[key + 1].transform.localPosition.x) * 0.5f;
            _labels[index].transform.localPosition = new Vector3(x, 0, 0);
            index++;
        }
    }
    /// <summary>
    /// 时间戳列表
    /// 会根据时间占比设置宽度
    /// </summary>
    /// <param name="timeStampList"></param>
    private void SetTimeStampList(List<long> timeStampList)
    {
        if (timeStampList == null)
        {
            return;
        }
        if (timeStampList.Count <= 1)
        {
            Debug.LogErrorFormat("列表的长度需要大于1");
            return;
        }
        _timeStampList = timeStampList;

        long timeStamp = 1;
        long endTimeStamp = _timeStampList[_count - 1];
        long startTimeStamp = _timeStampList[0];
        //总得时间跨度
        long totalTimeStamp = endTimeStamp - startTimeStamp;
        //已过时间占比
        float pro = (float)(timeStamp - startTimeStamp) / totalTimeStamp;
        pro = pro > 1 ? 1 : pro;
        _progress.sizeDelta = new Vector2(_width * pro, _height);
        _toggles[_currentIndex].transform.Find("Background/BigPoint").gameObject.Show();
        for (int i = 0; i < _count; i++)
        {
            //设置节点的位置
            float x = _width * (_timeStampList[i] - startTimeStamp) / totalTimeStamp - 0.5f * _width;
            _parent.GetChild(i).transform.localPosition = new Vector3(x, 0);

            //根据进度设置节点的颜色
            bool isReach = i < _currentIndex;
            _parent.GetChild(i).transform.Find("Background").GetComponent<Image>().color = isReach ? ColorOn : ColorOff;
            _parent.GetChild(_currentIndex).transform.Find("Background").GetComponent<Image>().color = ColorSelect;
        }
        SetTipsState(true);
    }

    public void StartByTime()
    {
        //开始定时去刷新
        CancelInvoke("UpdateState");
        InvokeRepeating("UpdateState", 0, 60);
    }

    private void UpdateState()
    {
        long timeStamp = 1;
        long endTimeStamp = _timeStampList[_count - 1];
        long startTimeStamp = _timeStampList[0];
        //总得时间跨度
        long totalTimeStamp = endTimeStamp - startTimeStamp;
        //已过时间占比
        float pro = (float)(timeStamp - startTimeStamp) / totalTimeStamp;
        pro = pro > 1 ? 1 : pro;
        _progress.sizeDelta = new Vector2(_width * pro, _height);

        int temp = GetCurrent(timeStamp);
        if (temp != _currentIndex)
        {
            _toggles[_currentIndex].transform.Find("Background/BigPoint").gameObject.Hide();
            _currentIndex = temp;
            _toggles[_currentIndex].transform.Find("Background/BigPoint").gameObject.Show();
            for (int i = 0; i < _count; i++)
            {
                //设置节点的位置
                float x = _width * (_timeStampList[i] - startTimeStamp) / totalTimeStamp - 0.5f * _width;
                _parent.GetChild(i).transform.localPosition = new Vector3(x, 0);

                //根据进度设置节点的颜色
                bool isReach = i < _currentIndex;
                _parent.GetChild(i).transform.Find("Background").GetComponent<Image>().color = isReach ? ColorOn : ColorOff;
                _parent.GetChild(_currentIndex).transform.Find("Background").GetComponent<Image>().color = ColorSelect;
            }
            //设置Tips
            SetTipsState(true);
        }

        if (timeStamp > endTimeStamp)
        {
            CancelInvoke("UpdateState");
        }
    }


    /// <summary>
    /// 获取当前的下标
    /// </summary>
    private int GetCurrent(long timeStamp)
    {
        int current = 0;
        for (int i = 0; i < _count; i++)
        {
            if (timeStamp > _timeStampList[i])
            {
                current++;
            }
        }
        if (current >= _count)
        {
            current = _count - 1;
        }
        return current;
    }

    public void Set(TimeProcessConfig config)
    {
        SetCount(config.Count);
        SetTipsStyle(config.TipsConfig);
        SetTipsList(config.TipsList);
        SetTipsState(true);
        SetTimeStampList(config.TimeList);
        SetLabelList(config.LabelDict);
    }
}


public class TimeProcessConfig
{
    /// <summary>
    /// 节点的数量
    /// </summary>
    public int Count;
    /// <summary>
    /// tips 列表
    /// </summary>
    public List<string> TipsList;
    /// <summary>
    /// tips的配置
    /// </summary>
    public TipsConfig TipsConfig = new TipsConfig();
    /// <summary>
    /// tips的默认显示状态
    /// </summary>
    public bool TipsState = false;
    /// <summary>
    /// 时间戳列表
    /// </summary>
    public List<long> TimeList;
    /// <summary>
    /// 标签字典
    /// 节点的下标-节点的内容
    /// </summary>
    public Dictionary<int, string> LabelDict;
}
