using System.Collections.Generic;
using Models;
using System.IO;
using System.Text.Json;
using System;
using System.Linq;

namespace DL {
    public class FileRepo : IRepo {
        private const string userFilePath = "../DL/User.json";
        private const string topFilePath = "../DL/Top.json";
        private string jsonString;

        public User AddUser(User user) {
            List<User> allUser = GetAllUser();

            allUser.Add(user);

            jsonString = JsonSerializer.Serialize(user);

            //write to a file
            File.WriteAllText(topFilePath, jsonString);

            return user;
        }

        public List<User> GetAllUser() {
            jsonString = File.ReadAllText(topFilePath);

            return JsonSerializer.Deserialize<List<User>>(jsonString);
        }

        public List<Top> GetAllTop() {
            jsonString = File.ReadAllText(userFilePath);

            return JsonSerializer.Deserialize<List<Top>>(jsonString);
        }
    }
}