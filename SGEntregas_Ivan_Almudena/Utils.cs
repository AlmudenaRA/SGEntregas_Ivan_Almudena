using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SGEntregas_Ivan_Almudena
{
    public class Utils
    {
        public static bool comprobarVacios(string str)
        {
            return str.Equals(string.Empty.Trim());           
        }

        public static bool validarFormatoDni(string dni)
        {
            if (dni == null)
            {
                return false;
            } else
                return Regex.IsMatch(dni.ToUpper(), "^[0-9]{8}-[A-Z]$");            
        }
    }
}
