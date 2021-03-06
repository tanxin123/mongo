﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb4Log
{
    /// <summary>
    /// 操作日志类
    /// 从配置文件中读取 配置
    /// </summary>
    public sealed class MongbdLog
    {
        public MongbdLog()
        {

        }
        public MongbdLog(string url)
        {
            client = new MongoClient(url);
            InitConfig();
            InitMongo();
        }
        public MongbdLog(MongoClientSettings settings)
        {
            client = new MongoClient(settings);
            InitConfig();
            InitMongo();
        }

        #region 属性


        public int Function
        {
            get
            {
                return _Function;
            }

            set
            {
                _Function = value;
            }
        }

        public int Thread
        {
            get
            {
                return _Thread;
            }

            set
            {
                _Thread = value;
            }
        }

        public int File
        {
            get
            {
                return _File;
            }

            set
            {
                _File = value;
            }
        }

        public int Line
        {
            get
            {
                return _Line;
            }

            set
            {
                _Line = value;
            }
        }

        public string Database
        {
            get
            {
                return _Database;
            }

            set
            {
                _Database = value;
            }
        }

        public Message Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
            }
        }
        #endregion

        #region 字段

        private string _Database;
        private int _Function;
        private int _Thread;
        private int _File;
        private int _Line;
        private Message _Message;
        #endregion

        private void InitConfig()
        {
            //_ConnectionString = MongbdLogUtil.GetByKey("ConnectionString");
            _Database = MongbdLogUtil.GetByKey("Database");
            int.TryParse(MongbdLogUtil.GetByKey("ConnectionString"), out _Function);
            int.TryParse(MongbdLogUtil.GetByKey("Thread"), out _Thread);
            int.TryParse(MongbdLogUtil.GetByKey("File"), out _File);
            int.TryParse(MongbdLogUtil.GetByKey("Line"), out _Line);
        }

        public IMongoClient client;
        public IMongoDatabase database;
        public IMongoCollection<Message> collection;

        private bool InitMongo()
        {
            try
            {
                database = client.GetDatabase(_Database); 

                collection = database.GetCollection<Message>("log_" + DateTime.Now.ToString("yyyy_MM_dd"));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Message InitMessage(string message = "", PriorityInfo priority = PriorityInfo.Debug)
        {
            Message messageInfo = new Message()
            {
                Priority = priority,
                Datetime = DateTime.Now,
                CurrentThread = _Thread == 1 ? System.Threading.Thread.CurrentThread.ManagedThreadId : 0,
                MessageInfo = message
            };
            _Message = messageInfo;
            return messageInfo;
        }

        public void SetMongoConfig(MongoClientSettings settings)
        {
            client = new MongoClient(settings);
        }

        public void InsertAsync(string message, PriorityInfo priority)
        {
            Message messageInfo = InitMessage(message, priority);
            Insert(messageInfo);
        }

        public void Insert(Message message)
        {
            collection.InsertOne(message);
            // collection.InsertOneAsync(message);
        }
        public async void InsertAsync(Message message)
        {
            //collection.InsertOne(message);
            await collection.InsertOneAsync(message);
        }
        private void InsertAsync()
        {
            InsertAsync(_Message);
        }


    }
}
