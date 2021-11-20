using Microsoft.AspNetCore.Identity;

namespace Pischool.Data.Migrations
{
    public class UserRepositury
    {
        private ApplicationDbContext _context;

        private UserManager<IdentityUser> _userManager;

        public UserRepositury(ApplicationDbContext context, UserManager<IdentityUser> manager)
        {
            _context = context;

            _userManager= manager;
        }
         
        public IEnumerable<IdentityUser> GetUsers()
        {
            return _userManager.Users.ToList();
        }

        public IEnumerable<string> GetEmails()
        {
            List<string> Emails = new List<string>();
            foreach (IdentityUser i in _context.Users)
            {
                Emails.Add(i.Email);
            }
            return Emails;
        }


        public void DeleteUser(string id)
        {
            try
            {
                var user = _context.Users.ToList().Find(x => x.Id == id);
                _userManager.DeleteAsync(user);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
