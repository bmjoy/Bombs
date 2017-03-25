﻿//using System.Collections.Generic;
//using GameEngine.Network;
//using System.IO;
//using System;
//using GameEngine.Script;
//namespace GameEngine
//{
//    public class LockStepGame
//    {
//        public List<Client> clients=new List<Client>();           // nth client also has entityId == n
//        public List<Input> messages=new List<Input>();  // server's network (where it receives inputs from clients)
//        private int seqNum = 0;
//        private int tickRate = 20;
//        public Dictionary<int, EntityControl> entities = new Dictionary<int, EntityControl>();
//        public void start()
//        {
//            System.Timers.Timer t = new System.Timers.Timer(1000 / this.tickRate);
//            t.Elapsed += new System.Timers.ElapsedEventHandler(update); //到达时间的时候执行事件；   
//            t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
//            t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
//        }

//        /// <summary>
//        /// 客户端加入--OK
//        /// </summary>
//        /// <param name="client"></param>
//        public void connect(Client client)
//        {
//            int entityId = client.Info.Id;
//            this.clients.Add(client);

//            GameObject entity = new GameObject(entityId);
//            EntityControl script = new EntityControl();
//            entity.AddScript(script);
//            this.entities.Add(entityId, script);

//            Input add_input = new Input();
//            add_input.seqNum = 0;
//            add_input.keycode = (int)KeyCode.I;
//            add_input.entityId = entityId;
//            AddMessage(add_input);
//        }
//        /// <summary>
//        /// 验证输入合法性--OK
//        /// </summary>
//        /// <param name="input"></param>
//        /// <returns></returns>
//        private bool validInput(Input input)
//        {
//            // Not exactly sure where 1/40 comes from.  I got it from the
//            // original code.  The longest possible valid "press" should be
//            // 1/client.tickRate (1/60).  But the JS timers are not reliable,
//            // so if you use 1/60 below you end up throwing out a lot of
//            // inputs that are slighly too long... so maybe that's where 1/40
//            // comes from?
//            //return System.Math.Abs(input.pressTime) <= 1 / 40;
//            return true;
//        }

//        /// <summary>
//        /// 更新
//        /// </summary>
//        /// <param name="source"></param>
//        /// <param name="e"></param>
//        public void update(object source, System.Timers.ElapsedEventArgs e)
//        {
//            if (_run) { return; }
//            _run = true;

//            seqNum++;

//            #region 把所有命令都发送给客户端
//            var ret = new MemoryStream();
//            var w = new BinaryWriter(ret);

//            w.Write(seqNum);
//            w.Write(messages.Count);
//            foreach (var item in messages)
//            {
//                item.Serialization(w);
//            }
//            messages.Clear();
//            byte[] datas = ret.ToArray();
//            foreach (var client in clients)
//            {
//                client.Send(31, datas);
//            }
//            #endregion

//            _run = false;
//        }

//        public void AddMessage(Input message)
//        {
//            message.recvTs = DateTime.Now.AddSeconds(message.lagMs);
//            this.messages.Add(message);
//        }
//        private bool _run = false;
//    }
//}
