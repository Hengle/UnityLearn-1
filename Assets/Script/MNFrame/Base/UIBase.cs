using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBase
{
    public override void ProcessEvent(MsgBase tempMsg)
    {
        throw new System.NotImplementedException();
    }

    public void RegistSelf(MonoBase mono, params ushort[] msg)
    {
        UIManager.Instance.RegistMsg(mono, msg);
    }

    public void UnRegistSelf(MonoBase mono, params ushort[] msg)
    {
        UIManager.Instance.UnRegistMsg(mono, msg);
    }

    public void SendMsg(MsgBase msg)
    {
        UIManager.Instance.SendMsg(msg);
    }

    public short[] msgIds;

    private void OnDestroy()
    {
        
    }
}
