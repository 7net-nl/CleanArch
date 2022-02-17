using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Contract.Interfaces.EF
{
    public interface IDataSet
    {
         DbSet<TodoList>  TodoLists { get; set; }
         DbSet<TodoItem>  TodoItems { get; set; }
    }
}
