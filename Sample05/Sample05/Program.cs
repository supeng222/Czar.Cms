using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Sample05.Models;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test_Insert();
            //Test_Mult_Insert();

            //Test_Del();
            //Test_Mult_Del();

            //Test_Update();
            //Test_Mult_Update();

            //Test_Select_One();
            //Test_Select_List();
            Test_Select_Content_With_Comment();

            Console.ReadLine();
        }

        /// <summary>
        /// 插入一条
        /// </summary>
        public static void Test_Insert()
        {
            var content = new Content
            {
                Title = "标题1",
                Contents = "内容1"
            };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
                VALUES (@title,@contents,@status,@add_time,@modify_time)";

                var result = conn.Execute(sql_insert, content);

                Console.WriteLine($"Test_Insert: 插入了{result}条数据");
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        public static void Test_Mult_Insert()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                Title = "批量插入标题1",
                Contents = "批量插入内容1",

            },
               new Content
            {
                Title = "批量插入标题2",
                Contents = "批量插入内容2",

            },
        };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
                VALUES   (@title,@contents,@status,@add_time,@modify_time)";

                var result = conn.Execute(sql_insert, contents);

                Console.WriteLine($"Test_Mult_Insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public static void Test_Del()
        {
            var id = new Content
            {
                Id = 3
            };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"delete from content where (id = @id)";

                var result = conn.Execute(sql_insert, id);

                Console.WriteLine($"Test_Del：删除了{result}条数据！");
            }

        }

        /// <summary>
        /// 测试一次批量删除两条数据
        /// </summary>
        public static void Test_Mult_Del()
        {
            List<Content> idList = new List<Content>()
            {
               new Content
               {
                   Id = 8,
               },
               new Content
               {
                   Id = 9,
               }
            };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"delete from content where (id = @id)";

                var result = conn.Execute(sql_insert, idList);

                Console.WriteLine($"Test_Mult_Del：删除了{result}条数据！");
            }
        }

        /// <summary>
        /// 修改一条数据
        /// </summary>
        public static void Test_Update()
        {
            var content = new Content
            {
                Id = 5,
                Title = "标题内容",
                Contents = "内容5"
            };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"update content set title = @title, content = @contents, modify_time = GETDATE() where (id = @id)";

                var result = conn.Execute(sql_insert, content);

                Console.WriteLine($"Test_Update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 批量修改数据
        /// </summary>
        public static void Test_Mult_Update()
        {
            var content = new List<Content>()
            {
                new Content
                {
                    Id = 6,
                    Title = "批量修改标题6",
                    Contents = "批量修改内容6",
                },
                new Content
                {
                    Id = 7,
                    Title = "批量修改标题7",
                    Contents = "批量修改内容7",
                },
            };

            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"update content set title = @title, content = @contents, modify_time = GETDATE() where (id = @id)";

                var result = conn.Execute(sql_insert, content);

                Console.WriteLine($"Test_Update：修改了{result}条数据！");
            }
        }

        /// <summary>
        /// 查询指定数据
        /// </summary>
        public static void Test_Select_One()
        {
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_select = @"select * from content where id = @id";

                var result = conn.QueryFirstOrDefault<Content>(sql_select, new { id = 5 });

                Console.WriteLine($"Test_Select_One：查询到：" + result.Id + result.Title + result.Contents 
                                 + result.Status + result.Add_Time, result.Modify_Time);
            }
        }

        /// <summary>
        /// 查询多条指定的数据
        /// </summary>
        static void Test_Select_List()
        {
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"select * from content where id in @id";

                var result = conn.Query<Content>(sql_insert, new { id = new int[] { 6, 7 } });

                foreach (var item in result)
                {
                    Console.WriteLine($"Test_Select_One：查询到：" + item.Id + item.Title + item.Contents
                                 + item.Status + item.Add_Time, item.Modify_Time);
                }
            }
        }

        /// <summary>
        /// 关联查询
        /// </summary>
        static void Test_Select_Content_With_Comment()
        {
            using (var conn = new SqlConnection("Data Source=.;User ID=sa;Password=!tjyrzxwbj@;Initial Catalog=Czar;" +
                                                "Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"select * from content where id=@id;
                                    select * from comment where content_id=@id;";
                using (var result = conn.QueryMultiple(sql_insert, new { id = 5 }))
                {
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    var x = content.Add_Time;
                    content.Comments = result.Read<Comment>();
                    Console.WriteLine($"test_select_content_with_comment:内容5的评论数量{content.Comments.Count()}");
                }
            }
        }
    }
}
