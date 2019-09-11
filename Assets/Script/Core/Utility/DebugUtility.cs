//from  https://www.jianshu.com/p/814b4b322623

using UnityEngine;

public class DebugUtility
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public void Log(object message)
    {
        Debug.Log(message);
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public void LogError(object message)
    {
        Debug.LogError(message);
    }

    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public void LogWarning(object message)
    {
        Debug.LogWarning(message);
    }
}
