using CleanArchitecture.Domain.Contract.Interfaces.EF;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.IDentities
{
    public class Users : IdentityUser , IUsers
    {

    }
}
