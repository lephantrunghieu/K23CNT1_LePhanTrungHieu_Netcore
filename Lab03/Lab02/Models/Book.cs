using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string? Sumary { get; set; }

        // danh sách các cuốn sách (nhớ using System.Collections.Generic)
        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
    {
        new Book()
        {
            Id = 1,
            Title = "Chí Phèo",
            AuthorId = 1,
            GenreId = 1,
            Image = "/images/products/b1.jpg",
            Price = 500000,
            Sumary = "",
            TotalPage = 250
        },
        new Book()
        {
            Id = 2,
            Title = "Nam Cao",
            AuthorId = 1,
            GenreId = 1,
            Image = "/images/products/b2.jpg",
            Price = 500000,
            Sumary = "",
            TotalPage = 250
        },
        new Book()
        {
            // Thêm sách khác tại đây nếu cần
        },
        new Book()
        {
            // Thêm sách khác tại đây nếu cần
        }
    };

            return books;
        }
        //chi tiết 1 cuốn sách theo id 
        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        // SelectListItem Authors (using Microsoft.AspNetCore.Mvc.Rendering)
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "1", Text = "Nam cao" },
        new SelectListItem { Value = "2", Text = "Ngô Tất Tố" },
        new SelectListItem { Value = "3", Text = "Adamkhoom" },
        new SelectListItem { Value = "4", Text = "Thiền sư Thích Nhất Hạnh" }
        };

        // SelectListItem Genres
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
        new SelectListItem { Value = "1", Text = "Truyện tranh" },
        new SelectListItem { Value = "2", Text = "Văn học đương đại" },
        new SelectListItem { Value = "3", Text = "Phật học phổ thông" },
        new SelectListItem { Value = "4", Text = "Truyện cười" }
        };

    }
}
