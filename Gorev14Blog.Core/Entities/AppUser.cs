using System.ComponentModel.DataAnnotations;

namespace Gorev14Blog.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Name { get; set; }
        [Display(Name = "Soyadı")]
        public string? Surname { get; set; }
        public string? Email { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Aktif?")]
        public bool IsActive { get; set; }
        [Display(Name = "Admin?")]
        public bool IsAdmin { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Eklenme Tarihi")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }
        [ScaffoldColumn(false)]
        public string? RefreshToken { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}
