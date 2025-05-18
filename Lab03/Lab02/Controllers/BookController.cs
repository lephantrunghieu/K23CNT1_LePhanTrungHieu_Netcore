using Microsoft.AspNetCore.Mvc;
using Lab03.Models;
namespace Lab03.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();

        public IActionResult Index()
        {
            // danh sách genres convert SelectListItem để hiển thị trên combobox
            ViewBag.authors = book.Authors; // truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;   // truyền dữ liệu SelectListItem qua view
            var books = book.GetBookList();
            return View(books); // truyền dữ liệu qua view dưới dạng tham số
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;  // truyền dữ liệu SelectListItem qua view
            ViewBag.genres = book.Genres;    // truyền dữ liệu SelectListItem qua view
            Book model = new Book();
            return View(model);
        }


    }
}
