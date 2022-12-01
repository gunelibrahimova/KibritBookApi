using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBookManager
    {
        void AddBook(BookDTO bookDTO);
        void UpdateBook(BookDTO bookDTO, int id);
        void RemoveBook(BookDTO bookDTO, int id);
        List<BookDTO> GetAllBookList();
        BookDTO GetBookById(int id);
    }
}
