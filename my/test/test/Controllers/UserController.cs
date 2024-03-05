using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "John" },
            new User { Id = 2, Name = "Alice" },
            new User { Id = 3, Name = "Bob" }
        };

        // GET: /User/
        public IActionResult Index()
        {
            return View(_users);
        }

        // GET: /User/Details/1
        public IActionResult Details(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = _users.Count + 1; // Generate new ID
                _users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /User/Edit/1
        public IActionResult Edit(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: /User/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var index = _users.FindIndex(u => u.Id == id);
                if (index == -1)
                {
                    return NotFound();
                }
                _users[index] = user;
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: /User/Delete/1
        public IActionResult Delete(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _users.Remove(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
