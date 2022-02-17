using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Entity
    {
        public long ID { get; set; }

        public string _id { get; set; } = Guid.NewGuid().ToString();

    }
}
