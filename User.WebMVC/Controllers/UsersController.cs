using Microsoft.AspNetCore.Mvc;
using Users.DAL.Repositories.Interfaces;
using Users.ReadModels;

namespace Users.WebMVC.Controllers
{
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        // GET: UsersController
        public ActionResult List()
        {
            var users = _userRepository.GetUsers();
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var user = _userRepository.GetUserById(id);
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReadModels.User user)
        {
            try
            {
                bool result = _userRepository.SaveUser(user);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userRepository.GetUserById(id);
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                _userRepository.UpdateUser(user);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _userRepository.GetUserById(id);
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _userRepository.DeleteUser(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
