public class MsgBase
{
    private ushort _msgId;

    public MsgBase(ushort msgId)
    {
        _msgId = msgId;
    }

    public ManagerId GetManagerId()
    {
        int tempId = _msgId / FrameTool.MsgSpan;
        return (ManagerId)(tempId * FrameTool.MsgSpan);
    }
}
