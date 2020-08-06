using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Login
    {
        private BADEntities bd;
        public Login()
        {
            bd = new BADEntities();
        }

        public ShippingLine Authentication(string username, string password)
        {
            return bd.ShippingLine.FirstOrDefault(u => u.Login == username && u.Password == password);
        }

        public ShippingLine GetUser(int id)
        {
            return bd.ShippingLine.FirstOrDefault(u => u.ShippingLineID == id);
        }

    }
}
