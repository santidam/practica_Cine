using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Practica01.model
{
    public class Controlador
    {
        public Boolean validUser(String correo, String password)
        {
            return true;
        }
        public Boolean valMail(String corroe)
        {
            return true;
        }
        public Boolean valPassword(String password)
        {
            Boolean aux = true;
            if (password.Length > 4)
            {
                aux = false;
            }
            return aux;
        }
    }
}
