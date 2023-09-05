using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorizationManager
    {
        Repository<Admin> AdminMan = new Repository<Admin>();

        public List<Admin> GetAll()
        {
            return AdminMan.List();
        }
        public void DeleteAdminBl(int p)
        {
            Admin admin = AdminMan.Find(x => x.AdminID == p);
             AdminMan.Delete(admin);
        }
        public Admin FindAdmin(int p)
        {
            return AdminMan.Find(x => x.AdminID == p);
        }
        public void AdminUpdateBL(Admin a)
        {
            Admin admin = AdminMan.Find(x => x.AdminID == a.AdminID);
            admin.AdminRole = a.AdminRole;
            admin.UserName = a.UserName;
            admin.Password = a.Password;
            if (a.UserName == "" || a.Password == "" )
            {
                return;   
            }
             AdminMan.Update(admin);

        }

        public void AdminAddBL(Admin a)
        {
            
             AdminMan.Insert(a);
        }

    }
}
