using Microsoft.AspNetCore.Identity;
using Pischool.Data;


namespace Pischool.Models
{
    public class RoleRepository
    {
        private ApplicationDbContext _context;//для связи с бд

        private RoleManager<IdentityRole> _role;// для управления ролями в приложении

        public RoleRepository(ApplicationDbContext context, RoleManager<IdentityRole> role)
        {
            _context = context;
            _role = role;
        }

        public  List<IdentityRole> GetRole()
        {
            _role.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" });
            return _role.Roles.ToList();
        }
    }
}
