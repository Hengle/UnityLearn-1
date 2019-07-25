using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNode
{
    //当前的数据
    public MonoBase data;
    //下一个节点
    public EventNode next;

    public EventNode(MonoBase monoBase)
    {
        data = monoBase;
        next = null;
    }
}

public class ManagerBase : MonoBase
{
    //存储罅隙
    public Dictionary<ushort, EventNode> EventTree = new Dictionary<ushort, EventNode>();

    /// <summary>
    /// 注册多个msg
    /// </summary>
    /// <param name="monoBase">要注册的脚本</param>
    /// <param name="msgs">脚本可以注册多个msg</param>
    public void RegistMsg(MonoBase monoBase, params ushort[] msgs)
    {
        for (int i = 0; i < msgs.Length; i++)
        {
            EventNode eventNode = new EventNode(monoBase);
            EventTree.Add(msgs[i], eventNode);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id">msg id</param>
    /// <param name="eventNode">链表</param>
    public void RegistMsg(ushort id, EventNode eventNode)
    {
        //数据链路里面没有这个消息
        if (!EventTree.ContainsKey(id))
        {
            EventTree.Add(id, eventNode);
        }
        else
        {
            EventNode tempNode = EventTree[id];
            //找到最后一个
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }
            //直接挂到最后一个
            tempNode.next = eventNode;
        }
    }
}
