using System.ComponentModel.DataAnnotations;

namespace Gorev14Blog.Core.Entities
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        [ScaffoldColumn(false)]
        public Guid? UserGuid { get; set; }
        [ScaffoldColumn(false)]
        public string? RefreshToken { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? RefreshTokenExpireDate { get; set; }
    }
}
