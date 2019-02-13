using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample01.Models
{
    public class Content
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string ContentMessage { get; set; }

        /// <summary>
        /// 状态 1 正常、 0 删除
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Add_Time { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Modify_Time { get; set; }
    }
}
