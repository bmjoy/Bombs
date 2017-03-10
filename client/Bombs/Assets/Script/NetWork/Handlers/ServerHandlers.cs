﻿using google.protobuf;
using System.IO;

public partial class LoginServerHandlers : PacketHandlerManager
{
    [PacketHandler(10)]
    public void LoginResult(Client client, byte[] datas, ushort start, ushort length)
    {
        PlayerInfo result;
        RecvData<PlayerInfo>(datas, out result, start, length);
        if(result!=null)
        {
            UnityEngine.Debug.Log("登陆返回结果：true");
        }
        if (LoginEvent != null)
        {
            LoginEvent(result);
        }
    }

    [PacketHandler(21)]
    public void JoinRoom(Client client, byte[] datas, ushort start, ushort length)
    {
        CommResult result;
        RecvData<CommResult>(datas, out result, start, length);
        UnityEngine.Debug.Log("加入房间返回结果：" + result.Result);
    }

    [PacketHandler(30)]
    public void WorldState(Client client, byte[] datas, ushort start, ushort length)
    {
        WorldState result = new global::WorldState();
        using (MemoryStream memoryStream = new MemoryStream(datas,start,length))
        {
            BinaryReader binaryReader = new BinaryReader(memoryStream);
            result.DeSerialization(binaryReader);
        }
        if (WorldStateEvent != null) { WorldStateEvent(result); }
    }

    public event CallBack<PlayerInfo> LoginEvent;
    public event CallBack<WorldState> WorldStateEvent;
}
