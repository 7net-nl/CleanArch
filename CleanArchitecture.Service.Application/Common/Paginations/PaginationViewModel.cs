using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.Common.Paginations
{
    public class PaginationViewModel
    {
        public short TotalPage { get; set; }
        public short CurrentPage { get; set; }
        public short CountOnPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
