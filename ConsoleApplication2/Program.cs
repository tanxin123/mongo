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

            MongbdLog log = new MongbdLog("mongodb://localhost:27017");
            log.InsertAsync("我是测试数据,不用管", PriorityInfo.Debug);
            Console.ReadLine();
        }

    }

}
