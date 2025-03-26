using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist); // Return a view with the user list
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return a 404 if the user is not found
            }
            return View(user); // Return the details view with the user data
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View(); // Return the Create view
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user == null)
            {
                return BadRequest(); // Return a 400 Bad Request if the user is null
            }

            userlist.Add(user); // Add the new user to the user list
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return a 404 if the user is not found
            }
            return View(user); // Return the Edit view with the user data
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (user == null)
            {
                return BadRequest(); // Return a 400 Bad Request if the user is null
            }

            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound(); // Return a 404 if the user is not found
            }

            // Update the existing user's properties
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return a 404 if the user is not found
            }
            return View(user); // Return the Delete confirmation view with the user data
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return a 404 if the user is not found
            }

            userlist.Remove(user); // Remove the user from the list
            return RedirectToAction(nameof(Index)); // Redirect to the Index action
        }

        // GET: User/SearchByName
        public IActionResult SearchByName(string query)
        {
            var results = userlist
                .Where(u => u.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View("SearchResults", results);
        }
}
