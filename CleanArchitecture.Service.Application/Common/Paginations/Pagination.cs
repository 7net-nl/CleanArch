using CleanArchitecture.Domain.Contract.Repositories;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Service.Application.Common.Paginations
{
    public static class Pagination
    {
        
        public static PaginationViewModel Set(short CurrentPage = 1, short CountOnPage = 1,int Count = 1)
        {
           
            var TotalPage = Count / (double)CountOnPage;

            var Model = new PaginationViewModel
            {
                TotalPage = (short)Math.Ceiling(TotalPage),
                CountOnPage = CountOnPage,
                CurrentPage = CurrentPage,
                HasNextPage = TotalPage > CurrentPage ? true : false,
                HasPreviousPage = CurrentPage < 1 ? true : false

            };

            return Model;

           





        }
    }
}
