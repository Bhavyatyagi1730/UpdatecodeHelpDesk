using Service.Entities;
using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICreateUser
    {
        List<LoginViewModel> GetAllUser();
        LoginViewModel GetUserById(int id);
        //void AddUser(LoginViewModel product);
        void UpdateUser(UserTable product);
        //void DeleteUser(int id);

    }
}
