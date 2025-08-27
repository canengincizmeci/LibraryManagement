using LibraryManagement.Core.DataAccess.EfCore;
using LibraryManagement.DataAccess.Abstract;
using LibraryManagement.Entities.Concrete;
using LibraryManagement.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LibraryManagement.DataAccess.Concrete.EfCore
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibDbContext>, IBookDal
    {
        public EfBookDal(LibDbContext context) : base(context)
        {
        }





    }
}
