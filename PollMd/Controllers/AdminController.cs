using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PollMd.Data;
using PollMd.Models.ViewModels;

namespace PollMd.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: AdminController
        public ActionResult Index()
        {
            var roles = _context.Roles.ToList();
            var userRoles = _context.UserRoles.ToList();

            ViewBag.Roles = new List<SelectListItem>();
            foreach (var item in roles)
            {
                ViewBag.Roles.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name
                });
            }

            var users = _context.Users;
            var usersWithRoles = new List<UserWithRoles>();

            foreach (var u in users)
            {
                var ur = userRoles.Where(x => x.UserId == u.Id).Select(x => x.RoleId).ToList();
                var uwr = new UserWithRoles
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Roles = roles.Where(x => ur.Contains(x.Id)).Select(x => x.Name).ToList()
                };

                usersWithRoles.Add(uwr);
            }
            return View(usersWithRoles);
        }

        // GET: AdminController/Create
        public ActionResult CreateRole()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRole(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: AdminController/Create
        [HttpPost]
        public async Task<IActionResult> SetUserRoleAsync(string userId, string role)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Find(userId);
                await _userManager.AddToRoleAsync(user, role);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
