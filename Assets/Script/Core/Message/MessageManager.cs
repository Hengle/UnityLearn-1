using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    private static MessageModel _mode = new MessageModel();

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="actionName">事件名称</param>
    /// <param name="action">事件</param>
    public static void AddListener(string actionName, Action action)
    {
        if (action == null)
        {
            throw new Exception("事件为空：" + actionName);
        }

        if (_mode.DelegateDict.ContainsKey(actionName))
        {
            Delegate temp = _mode.DelegateDict[actionName];

            if (!temp.GetType().Equals(action.GetType()))
            {
                throw new Exception("参数类型不对：" + temp.GetType() + "_" + action.GetType());
            }

            Delegate delegates = Delegate.Combine(temp, action);

            _mode.DelegateDict[actionName] = delegates;
        }
        else
        {
            _mode.DelegateDict.Add(actionName, action);
        }
    }

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="actionName"></param>
    /// <param name="action"></param>
    public static void AddListener<T>(string actionName, Action<T> action)
    {
        if (action == null)
        {
            throw new Exception("事件为空：" + actionName);
        }

        if (_mode.DelegateDict.ContainsKey(actionName))
        {
            Delegate temp = _mode.DelegateDict[actionName];

            if (!temp.GetType().Equals(action.GetType()))
            {
                throw new Exception("参数类型不对：" + temp.GetType() + "_" + action.GetType());
            }

            Delegate delegates = Delegate.Combine(temp, action);
            _mode.DelegateDict[actionName] = delegates;
        }
        else
        {
            _mode.DelegateDict.Add(actionName, action);
        }
    }

    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="actionName">事件名称</param>
    public static void TriggerListener(string actionName)
    {
        if (!_mode.DelegateDict.ContainsKey(actionName))
        {
            throw new Exception("不存在该事件：" + actionName);
        }

        Delegate[] delegates = _mode.DelegateDict[actionName].GetInvocationList();

        for (int i = 0; i < delegates.Length; i++)
        {
            Action action = delegates[i] as Action;
            action();
        }
    }

    public static void TriggerListener<T>(string actionName, T t)
    {
        if (!_mode.DelegateDict.ContainsKey(actionName))
        {
            throw new Exception("不存在该事件：" + actionName);
        }

        Delegate[] delegates = _mode.DelegateDict[actionName].GetInvocationList();

        for (int i = 0; i < delegates.Length; i++)
        {
            if (!(delegates[i] is Action<T> action))
            {
                throw new Exception("参数类型不对应：" + actionName + "_" + delegates[i].GetType() + "_" + t.GetType());
            }
            action(t);
        }
    }

    /// <summary>
    /// 移除actionName对应的所有事件
    /// </summary>
    /// <param name="actionName"></param>
    public static void RemoveListtener(string actionName)
    {
        if (!_mode.DelegateDict.ContainsKey(actionName))
        {
            throw new Exception("不存在该事件：" + actionName);
        }
        Delegate[] delegates = _mode.DelegateDict[actionName].GetInvocationList();

        for (int i = 0; i < delegates.Length; i++)
        {
            delegates[i] = null;
        }

        Delegate.RemoveAll(_mode.DelegateDict[actionName], _mode.DelegateDict[actionName]);
        _mode.DelegateDict.Remove(actionName);
    }

    /// <summary>
    /// 移除actionName对应的所有事件中的某一个
    /// </summary>
    /// <param name="actionName"></param>
    /// <param name="action"></param>
    public static void RemoveListtener(string actionName, Action action)
    {
        if (!_mode.DelegateDict.ContainsKey(actionName))
        {
            throw new Exception("不存在该事件：" + actionName);
        }
        _mode.DelegateDict[actionName] = Delegate.Remove(_mode.DelegateDict[actionName], action);

        if (_mode.DelegateDict[actionName] == null)
        {
            _mode.DelegateDict.Remove(actionName);
        }
    }

    public static void RemoveListtener<T>(string actionName, Action<T> action)
    {
        if (!_mode.DelegateDict.ContainsKey(actionName))
        {
            throw new Exception("不存在该事件：" + actionName);
        }
        if (!_mode.DelegateDict[actionName].GetType().Equals(action.GetType()))
        {
            throw new Exception("参数类型不对应：" + actionName + "_" + _mode.DelegateDict[actionName].GetType() + "_" + action.GetType());
        }

        _mode.DelegateDict[actionName] = (Action<T>)Delegate.Remove(_mode.DelegateDict[actionName], action);

        if (_mode.DelegateDict[actionName] == null)
        {
            _mode.DelegateDict.Remove(actionName);
        }
    }

    /// <summary>
    /// 清理
    /// </summary>
    public static void Clear()
    {
        var enumerator = _mode.DelegateDict.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Delegate temp = enumerator.Current.Value;
            temp = Delegate.RemoveAll(temp, temp);
            temp = null;
        }
        _mode.DelegateDict.Clear();
    }
}

public class MessageModel
{
    public Dictionary<string, Delegate> DelegateDict;


    public MessageModel()
    {
        DelegateDict = new Dictionary<string, Delegate>();
    }
}

public struct ActionName
{
    public readonly static string TEST_1 = "TEST_1";
}
