using LibraryManagement.Core.DataAccess;
using LibraryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess.Abstract
{
    public interface IBookDal:IEntityRepository<Book>
    {

    }
}
