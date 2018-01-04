using MongoDB.Driver;
using Mongodb4Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string mesg1 = "mesg1";
            //string mesg2 = "mesg2";
            //string mesg3 = "mesg3";
            //string mesg4 = "mesg4";


            //string connectionString = "mongodb://localhost:27017";
            //var client = new MongoClient(connectionString);
            //var database = client.GetDatabase("log4mongo");
            //var collection = database.GetCollection<Message>("message");
            //collection.InsertOne(new Message()
            //{
            //    //datetime = DateTime.Now,
            //    //priority = "info",
            //    //message = mesg1
            //});

            MongbdLog log = MongbdLog.Instance;
            log.InsertAsync("我是测试数据,不用管",PriorityInfo.Debug);
        }

    }

}
