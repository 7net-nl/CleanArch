using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.IDentities.Commands.Users.LogInApiKey
{
    public static class GenerationCustomApiKey
    {
        public static string Get()
        {
            var Chars = "dsfdsfsf54f5s4f56s4fsdfsdf56465s4f65s4f6544sd6fs4";
            var Result = new char[300];
           
            for (int i = 0; i < Result.Length; i++)
            {
                Result[i] = Chars[new Random().Next(Chars.Length)];
            }
            return new string(Result);
        }
    }
}
