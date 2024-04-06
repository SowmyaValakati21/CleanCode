// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var userManagement = new UserManagement();

userManagement.AddNewUser("Alice", "Admin");
userManagement.AddNewUser("Bob", "Member");
userManagement.AddNewUser("Charlie", "Member");

var users = userManagement.GetAllUsers();
foreach (var user in users)
{
    Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}, Role: {user.Role}");
}

//update user 

// Assuming Bob's UserId is 2 (You need to check the correct UserId from your database) just check 
userManagement.UpdateUser(2, "Bob", "Admin");
var updatedUser = userManagement.GetUserById(2);
Console.WriteLine($"Updated Info - ID: {updatedUser.UserId}, Name: {updatedUser.UserName}, Role: {updatedUser.Role}");

//delete user

// Assuming Charlie's UserId is 3
userManagement.DeleteUser(3);

//retrive all users
var remainingUsers = userManagement.GetAllUsers();
foreach (var user in remainingUsers)
{
    Console.WriteLine($"ID: {user.UserId}, Name: {user.UserName}, Role: {user.Role}");
}



Console.ReadKey();