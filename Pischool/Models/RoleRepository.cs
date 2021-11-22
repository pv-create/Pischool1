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

        public List<IdentityRole> GetRole()
        {
            return _context.Roles.ToList();
        }

        public IdentityRole GetRoleById(string Id)
        {
            var role= GetRole().FirstOrDefault(r => r.Id == Id);
            return role;
        }

        public void DeleteRole(string Id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == Id);
            _context.Roles.Remove(role);
        }
    }
}
