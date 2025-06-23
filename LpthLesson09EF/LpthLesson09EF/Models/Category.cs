using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LpthLesson09EF.Models;

public partial class Category
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Tên danh mục không được để trống")]
    [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
    [Display(Name = "Tên danh mục")]
    public string? CategoryName { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
