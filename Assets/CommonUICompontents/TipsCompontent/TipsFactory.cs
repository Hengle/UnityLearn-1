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
public class TipsFactory : MonoSingleton<TipsFactory>
{
    public TipsCompontent GetTips(TipsSize tipsSize, TipsDirection tipsDirection)
    {
        string path = "Common/TipsCompontent/Tips_" + tipsSize + "_" + tipsDirection;
        return UIFactory.Instance.GetUI<TipsCompontent>(path);
    }



    public void Dispose()
    {

    }
}
