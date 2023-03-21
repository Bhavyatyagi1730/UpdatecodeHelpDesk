using Model;
using Service.Entities;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Service.Class
{
   public  class CreateUser : ICreateUser
    {
         HelpdeskEntities db1 = new HelpdeskEntities();
        
            LoginViewModel user = new LoginViewModel();
        public LoginViewModel GetUserById(int id)
        {
            LoginViewModel user = new LoginViewModel();
            var row = db1.UserTables.Where(model=>model.Id== id).FirstOrDefault();
            user.Id= row.Id;
            return user;
        }

        //public void AddUser(LoginViewModel newUser)
        //{
        //    db1.HelpDesks.Add(newUser);
        //    db1.SaveChanges();

        //}
        public void UpdateUser(UserTable newUser)
        {
            db1.Entry(newUser).State = EntityState.Modified;
            db1.SaveChanges();
        }

        List<LoginViewModel> ICreateUser.GetAllUser()
        {
            throw new NotImplementedException();
        }


        //public void DeleteProduct(int id)
        //{
        //    LoginViewModel product = db1.HelpDesks.Find(Id);
        //    _context.Products.Remove(product);
        //    _context.SaveChanges();
        //}





    }
}
