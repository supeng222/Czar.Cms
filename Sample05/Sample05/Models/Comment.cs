using System;
using System.Collections.Generic;
using System.Text;

namespace Sample05.Models
{
    public class Comment
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 文章Id
        /// </summary>
        public int Content_Id { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 添加事件
        /// </summary>
        public DateTime Add_Time { get; set; }
    }
}
