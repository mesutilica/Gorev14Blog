using System.ComponentModel.DataAnnotations;

namespace Gorev14Blog.Core.Entities
{
    public class Post : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Resim")]
        public string? Image { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Kategori")]
        public Category? Category { get; set; }
    }
}
