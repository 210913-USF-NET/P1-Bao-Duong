using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {   
        List<User> GetAllUser();
        User AddUser(User user);

        List<Top> GetAllTop();
    }
}