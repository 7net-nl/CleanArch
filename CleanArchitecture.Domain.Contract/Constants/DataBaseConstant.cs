using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Contract.Constants
{
    public static class DataBaseConstant
    {
        public const string UserName = "Admin";
        public const string Password = "Admin@123";
        public const string SqliteConnectionString = "FileName=./CleanArchitecture.db";
        public const string SqliteConnectionStringIDentity = "FileName=./CleanArchitectureIDentity.db";
        public const string SqliteIDentityServer = "FileName=./IDentityServer.db";
        public const string SqliteHangFire = "FileName=./HangFire.db";
    }
}
