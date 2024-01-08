using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class UserManagement
    {
        private Dictionary<string, string> users = new Dictionary<string, string>();

        public void AddNewUser(string userName, string role)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Username and role cannot be null or empty.");
            }

            try
            {
                using (var context = new UserManagementContext())
                {
                    var user = new User { UserName = userName, Role = role };
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                // You can also decide to rethrow the exception or handle it based on your application's needs
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public User GetUserById(int userId)
        {
            using (var context = new UserManagementContext())
            {
                return context.Users.FirstOrDefault(u => u.UserId == userId);
            }
        }
        public List<User> GetAllUsers()
        {
            using (var context = new UserManagementContext())
            {
                return context.Users.ToList();
            }
        }

        public void UpdateUser(int userId, string newUserName, string newRole)
        {
            using (var context = new UserManagementContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    user.UserName = newUserName;
                    user.Role = newRole;
                    context.SaveChanges();
                }
            }
        }
        public void DeleteUser(int userId)
        {
            using (var context = new UserManagementContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
