using System.Collections.Generic;
using UnityEngine;

//tips的大小
public enum TipsSize
{
    Small,
    Middle,
    Large
}

//tips箭头的指向
public enum TipsDirection
{
    Up,
    Down,
    Left,
    Right
}

//
// 摘要:
//     Where the anchor of the text is placed.
public enum TextAnchor1
{
    //
    // 摘要:
    //     Text is anchored in upper left corner.
    UpperLeft = 0,
    //
    // 摘要:
    //     Text is anchored in upper side, centered horizontally.
    UpperCenter = 1,
    //
    // 摘要:
    //     Text is anchored in upper right corner.
    UpperRight = 2,
    //
    // 摘要:
    //     Text is anchored in left side, centered vertically.
    MiddleLeft = 3,
    //
    // 摘要:
    //     Text is centered both horizontally and vertically.
    MiddleCenter = 4,
    //
    // 摘要:
    //     Text is anchored in right side, centered vertically.
    MiddleRight = 5,
    //
    // 摘要:
    //     Text is anchored in lower left corner.
    LowerLeft = 6,
    //
    // 摘要:
    //     Text is anchored in lower side, centered horizontally.
    LowerCenter = 7,
    //
    // 摘要:
    //     Text is anchored in lower right corner.
    LowerRight = 8
}
//tips的生命周期
public enum LifeCycle
{
    Permanent,//永久，持续到界面销毁为止
              //持续时间3秒钟
              //持续到手动点击关闭

}
//关闭方式
//点击屏幕任意位置关闭
//点击指定toggle/button 关闭
public class TipsFactory
{

    public static TipsFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TipsFactory();
            }
            return _instance;
        }
    }
    private static TipsFactory _instance;

    private TipsFactory() { }


    //对象池
    private Dictionary<string, TipsCompontent> _compontentPool = new Dictionary<string, TipsCompontent>();

    public TipsCompontent GetTips(TipsConfig tipsConfig = null)
    {
        if (tipsConfig == null)
        {
            tipsConfig = new TipsConfig();
        }
        string path = "Common/TipsCompontent/Tips_" + tipsConfig.TipsSize + "_" + tipsConfig.TipsDirection;
        TipsCompontent tipsCompontent = UIFactory.Instance.GetUI<TipsCompontent>(path);
        tipsCompontent.SetStyle(tipsConfig);
        return tipsCompontent;
    }


    public void Dispose()
    {

    }
}


public class TipsConfig
{
    /// <summary>
    /// tips的大小
    /// </summary>
    public TipsSize TipsSize = TipsSize.Small;
    /// <summary>
    /// tips箭头的指向
    /// </summary>
    public TipsDirection TipsDirection = TipsDirection.Down;
    /// <summary>
    /// tips的缩放
    /// </summary>
    public float LocalScale = 1;
    /// <summary>
    /// tips内文本的字体大小
    /// </summary>
    public int FontSize = 18;
    /// <summary>
    /// tips箭头偏移量
    /// </summary>
    public Vector2 Offset = Vector3.zero;
    /// <summary>
    /// 点击任意键关闭
    /// </summary>
    public bool IsCloseAnyKey = false;
    /// <summary>
    /// 父节点
    /// </summary>
    public Transform Parent = null;
    /// <summary>
    /// 内容
    /// </summary>
    public string Content = string.Empty;
}