﻿using System.Net.Sockets;
using google.protobuf;
using System;
using System.IO;
using System.Collections.Generic;
using Model;

public partial class ClientHandler : PacketHandlerManager<Client>
{
    public static int id = 0;
    /// <summary>
    /// 客户端登陆
    /// </summary>
    /// <param name="client"></param>
    /// <param name="datas"></param>
    [PacketHandler(10)]
    public void Login(Client client, byte[] datas)
    {
        Log.Info("==客户端登陆==");
        LoginRequest request_login;
        RecvData<LoginRequest>(datas, out request_login);
        id++;
        CommResult response = new CommResult();
        response.Result = id;
        Program.game.SessionLogin(id, client );
        client.Send<CommResult>(10, response);
    }

    /// <summary>
    /// 上传数据
    /// </summary>
    /// <param name="client"></param>
    /// <param name="datas"></param>
    /// <param name="start"></param>
    /// <param name="length"></param>
    [PacketHandler(2)]
    public void UpMessage(Client client, byte[] datas)
    {
        Message request;
        RecvData<Message>(datas, out request);
        Program.game.AddMessage(request);
    }
}

