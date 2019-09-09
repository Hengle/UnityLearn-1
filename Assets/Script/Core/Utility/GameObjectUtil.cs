using UnityEngine;

public static class GameObjectUtil
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Hide(this GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="gameObject"></param>
    public static void Show(this GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
