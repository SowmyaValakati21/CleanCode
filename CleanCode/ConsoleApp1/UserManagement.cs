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
            ValidateUserName(userName);
            ValidateRole(role);
            if (!UserExists(userName))
            {
                users.Add(userName, role);
            }
        }

        public void RemoveUser(string userName, string executorRole)
        {
            ValidateUserName(userName);
            if (executorRole != "Admin")
            {
                throw new UnauthorizedAccessException("Only admins can remove users.");
            }

            if (UserExists(userName))
            {
                users.Remove(userName);
            }
        }

        public List<string> GetAllUsers()
        {
            if (IsUserListEmpty())
            {
                throw new InvalidOperationException("User list is empty.");
            }
            return new List<string>(users.Keys);
        }

        private bool UserExists(string userName)
        {
            return users.ContainsKey(userName);
        }

        private bool IsUserListEmpty()
        {
            return users.Count == 0;
        }

        private void ValidateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name cannot be null, empty, or whitespace.");
            }
        }

        private void ValidateRole(string role)
        {
            var validRoles = new List<string> { "Admin", "Member" };
            if (!validRoles.Contains(role))
            {
                throw new ArgumentException("Invalid role.");
            }
        }
    }
}
