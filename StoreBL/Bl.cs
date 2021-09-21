using System;
using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL
{
    public class Bl : IBl
    {
        private IRepo _repo;

        public Bl (IRepo repo) {
            this._repo = repo;
        }

        public User AddUser(User user) {
            return _repo.AddUser(user);
        } 

        public List<User> GetAllUser() {
            return _repo.GetAllUser();
        }

        public List<Top> GetAllTop() {
            return _repo.GetAllTop();
        }    
    }
}