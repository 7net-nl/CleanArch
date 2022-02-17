using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.IDentities
{
    public class DbContextIDentityEF : IdentityDbContext<Users>
    {
        public DbContextIDentityEF(DbContextOptions<DbContextIDentityEF> options) : base(options)
        {
        }


    }
}
