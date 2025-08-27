using LibraryManagement.Core.Utilities.Results;
using LibraryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Abstract
{
    public interface IBookService
    {
        IResult Add(Book book);
        IResult Update(Book book);

    }
}
