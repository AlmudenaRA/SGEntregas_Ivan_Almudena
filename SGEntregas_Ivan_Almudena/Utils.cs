using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGEntregas_Ivan_Almudena
{
    public class Utils
    {
        public static bool comprobarVacios(string str)
        {
            if (str.Equals(string.Empty.Trim()))
            {
                return true;
            }
            else return false;
        }
    }
}
