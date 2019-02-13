using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample01.Models;

namespace Sample01.Controllers
{
    public class ContentController : Controller
    {
        private readonly Content _contents;

        /// <summary>
        /// IOptions<Content> options 构造函数注入
        /// </summary>
        /// <param name="options"></param>
        public ContentController(IOptions<Content> options)
        {
            _contents = options.Value;
        }

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(new ContentViewModel() { Contents = new List<Content>() { _contents } });
        }
    }
}