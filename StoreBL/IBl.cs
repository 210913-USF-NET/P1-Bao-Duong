using System;
using System.Collections.Generic;
using Models;
using DL;

namespace StoreBL
{
    public interface IBl
    {
        User AddUser(User user);
        List<User> GetAllUser();

        List<Top> GetAllTop();
    }
}