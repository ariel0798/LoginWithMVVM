using LoginWithMVVM.Model;
using LoginWithMVVM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LoginWithMVVM.Services
{
    public class UserService : IUserService
    {
        readonly string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.txt");
        List<User> GetUserList()
        {
            if (!File.Exists(filePath))
                File.CreateText(filePath);

            var lines = File.ReadAllLines(filePath).ToList();

            var userList = new List<User>();

            foreach (var line in lines)
            {
                var lineArr = line.Split('|');
                var user = new User();
                user.Name = lineArr[0];
                user.Email = lineArr[1];
                user.Password = lineArr[2];

                userList.Add(user);
            }
            return userList;
        }

        public void AddUser(User user)
        {
            var userList = GetUserList();
            userList.Add(user);

            var lines = new List<string>();

            foreach (var userx in userList)
            {
                lines.Add(userx.Name + "|" + userx.Email + "|" + userx.Password);
            }

            File.WriteAllLines(filePath, lines);
        }

        public bool ExistingUser(string email, string password) =>
            GetUserList().Any(u => u.Email.ToLower() == email.ToLower() && u.Password == password);

        public bool ExistingEmail(string email) =>
            GetUserList().Any(u => u.Email.ToLower() == email.ToLower());

        public User GetUser(string email, string password) => 
            GetUserList().FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.Password == password);
    }
}
