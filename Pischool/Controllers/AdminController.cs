
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pischool.Data;
using Pischool.Data.Migrations;
using Pischool.Models;

namespace Pischool.Controllers
{
    public class AdminContriller : Controller
    {
        private UserRepositury _userRepository;

        private RoleRepository _roleRepository;

        public AdminContriller(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userRepository = new UserRepositury(context, userManager);

            _roleRepository = new RoleRepository(context, roleManager);
        }


        public IActionResult Index()
        {
            var users = _userRepository.GetUsers();
            var roles = _roleRepository.GetRole();
          
            ViewBag.Users = users;

            ViewBag.Role = roles;

            return View(users);
        }

        public IActionResult GetEmails()
        {
            var EmailsList=_userRepository.GetEmails();
            ViewBag.Emails = EmailsList;
            return View(EmailsList);
        }


    }
}
