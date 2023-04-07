using System.ComponentModel.DataAnnotations;

namespace Gorev14Blog.Core.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
