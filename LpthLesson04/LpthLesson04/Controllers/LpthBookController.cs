using LpthLesson04.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LpthLesson04.Controllers
{
    public class LpthBookController : Controller
    {
        // GET: /LpthBook/LpthIndex => Lay tat ca cuon sach 
        private List<LpthBook> lpthBooks = new List<LpthBook>
{
    new LpthBook
    {
        LpthId = "B001",
        LpthTitle = "Lập Trình C# Cơ Bản",
        LpthDescription = "Hướng dẫn lập trình C# từ cơ bản đến nâng cao.",
        LpthImage = "/images/b1.jpg",
        LpthPrice = 150000f,
        LpthPage = 320
    },
    new LpthBook
    {
        LpthId = "B002",
        LpthTitle = "ASP.NET Core Web API",
        LpthDescription = "Phát triển ứng dụng web với ASP.NET Core Web API.",
        LpthImage = "/images/b2.jpg",
        LpthPrice = 180000f,
        LpthPage = 400
    },
    new LpthBook
    {
        LpthId = "B003",
        LpthTitle = "Cấu Trúc Dữ Liệu và Giải Thuật",
        LpthDescription = "Tài liệu học về cấu trúc dữ liệu và thuật toán.",
        LpthImage = "/images/b3.jpg",
        LpthPrice = 175000f,
        LpthPage = 350
    },
    new LpthBook
    {
        LpthId = "B004",
        LpthTitle = "Lập Trình Python",
        LpthDescription = "Khóa học lập trình Python từ cơ bản đến nâng cao.",
        LpthImage = "/images/b4.jpg",
        LpthPrice = 165000f,
        LpthPage = 280
    },
    new LpthBook
    {
        LpthId = "B005",
        LpthTitle = "Thiết Kế Cơ Sở Dữ Liệu",
        LpthDescription = "Tìm hiểu cách thiết kế và tối ưu cơ sở dữ liệu.",
        LpthImage = "/images/b5.jpg",
        LpthPrice = 190000f,
        LpthPage = 370
    }
};
        public IActionResult LpthIndex()
        {
            // dua du lieu len view 
            return View(lpthBooks);
        }
        //GET: /LpthBook/LpthCreate
        public IActionResult LpthCreate()
        {
            LpthBook lpthBook = new LpthBook();
            return View(lpthBook);
        }
        //GET: /LpthBook/LpthCreate
        public IActionResult LpthCreateSubmit()
        {
            LpthBook lpthBook = new LpthBook();
            return RedirectToAction("LpthIndex");
        }
        //GET: /LpthBook/LpthEdit
        public IActionResult LpthEdit( string id)
        {

            return View();
        }
        //GET: /LpthBook/LpthEditSubmit
        public IActionResult LpthEditSubmit()
        {

            return RedirectToAction("LpthIndex");
        }
    }
}
