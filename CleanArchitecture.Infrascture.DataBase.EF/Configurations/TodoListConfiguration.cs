using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.DataBase.EF.Configurations
{
    public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(EntityTypeBuilder<TodoList> builder)
        {
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Title).HasMaxLength(50).IsRequired();

            builder.HasMany(c => c.TodoItems).WithOne().HasForeignKey(d => d.TodoList_ID).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
