using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.IDentities
{
    public class UserRandomPassword
    {
       
        
        public string Get()
        {
            var Text = "aqwertyuiopasdfghjklzxcvbnm";

            return new string(Enumerable.Repeat(Text, 30).Select(c => c[new Random().Next(Text.Length)]).ToArray());
        }
    }
}
