using CleanArchitecture.Domain.Contract.Interfaces;
using CleanArchitecture.Domain.Contract.Interfaces.EF;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF
{
    public class DBContextEF : DbContext ,IDataSet
    {
        public DBContextEF(DbContextOptions<DBContextEF> options) : base(options)
        {
        }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public void SaveChangesAsync()
        {
            SaveChangesAsync(cancellationToken: default);
        }



        public DbSet<TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
