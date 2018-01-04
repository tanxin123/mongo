using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodb4Log
{
    /// <summary>
    /// 需要插入 mongdb的数据 
    /// 已设置默认值
    /// </summary>
    [Serializable]
    public class Message
    {
        /// <summary>
        /// 插入时间
        /// </summary>
        public DateTime Datetime { get; set; } = DateTime.Now;
        /// <summary>
        /// 优先级
        /// </summary>
        public PriorityInfo Priority { get; set; } = PriorityInfo.Debug;
        /// <summary>
        /// 消息
        /// </summary>
        public string MessageInfo { get; set; } = string.Empty;
        /// <summary>
        /// 当前调用的函数名称
        /// </summary>
        public string CurrentFunction { get; set; } = string.Empty;
        /// <summary>
        /// 当前线程
        /// </summary>
        public int CurrentThread { get; set; } = 0;
        /// <summary>
        /// 当前所在文件
        /// </summary>
        public string CurrentFileName { get; set; } = string.Empty;
        /// <summary>
        /// 当前所在行
        /// </summary>
        public int CurrentLine { get; set; } = 0;

    }

    /// <summary>
    /// 日志优先级
    /// </summary>
    [Serializable]
    public enum PriorityInfo
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Error = 3,
        Fatal = 4,
    }
}
