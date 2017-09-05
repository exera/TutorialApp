using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class News
    {
        public int Id { get; set; }
        [Display(Name ="Başlık")]
        public string Title { get; set; }
        [Display(Name = "İçerik")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public int ImageId { get; set; }
        [Display(Name = "Resim")]
        public virtual Image Image { get; set; }
        [Display(Name = "Haber Tarihi")]
        public DateTime Date { get; set; }
        [Display(Name = "Etiketler")]
        public string Tags { get; set; }
        [Display(Name = "Kategori")]
        public string Category { get; set; }
        [Display(Name = "Slug")]
        public string Slug { get; set; }
    }
}