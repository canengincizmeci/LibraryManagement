using LibraryManagement.Business.Abstract;
using LibraryManagement.Business.Constants;
using LibraryManagement.Core.Utilities.Results;
using LibraryManagement.DataAccess.Abstract;
using LibraryManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IResult Add(Book book)
        {


            _bookDal.Add(book);
            return new SuccessResult("Ürün Eklendi");
        }

        public IResult Update(Book book)
        {
            var myBook = _bookDal.GetAll(p => p.Id == book.Id);
            if (myBook is null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }


            _bookDal.Update(book);
            return new SuccessResult(Messages.SuccessfulLogin);
        }
    }
}
