using UnityEngine;
using System.Collections.Generic;

public class UIManager : ManagerBase
{
    public static UIManager Instance { get; private set; }
    /// <summary>
    /// �涨�˿�����ʽ
    /// �����ڴ� ��ȡ�ٶ� �� ���� 
    /// </summary>
    private Dictionary<string, GameObject> _sonMember = new Dictionary<string, GameObject>();
    private void Awake()
    {
        Instance = this;
    }
    public void RegistGameObject(string name, GameObject obj)
    {
        if (!_sonMember.ContainsKey(name))
        {
            _sonMember.Add(name, obj);
        }
    }

    public void UnRegistGameObject(string name)
    {
        if (_sonMember.ContainsKey(name))
        {
            _sonMember.Remove(name);
        }
    }
    /// <summary>
    /// ������Ϣ
    /// </summary>
    /// <param name="msg"></param>
    public void SendMsg(MsgBase msg)
    {
        if (msg.GetManager() == ManagerId.UIManager)
        {
            //��ģ���Լ�����
            ProcessEvent(msg);
        }
        else //����msgCenter����
        {
            MsgCenter.Instance.SendToMsg(msg);
        }
    }
}