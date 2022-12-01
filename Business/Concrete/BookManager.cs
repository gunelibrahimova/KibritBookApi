using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BookManager : IBookManager
    {
        private readonly IBookDal _bookDal;
        private readonly IBookPictureManager _bookPictureManager;

        public BookManager(IBookDal productDal, IBookPictureManager productPictureManager)
        {
            _bookDal = productDal;
            _bookPictureManager = productPictureManager;
        }


        public void AddProduct(BookDTO bookDTO)
        {
            Book book = new()
            {
                Name = bookDTO.Name,
                Description = bookDTO.Description,
                Price = bookDTO.Price,
                SalePrice = bookDTO.SalePrice,
                PhotoURL = bookDTO.PhotoURL,
                Size = bookDTO.Size,
                isStock = bookDTO.isStock,
                isTranslate = bookDTO.isTranslate,
                Translator = bookDTO.Translator,
                BookCover = bookDTO.BookCover,
                PaperType = bookDTO.PaperType,
                PublisherId = bookDTO.Id,
                GenreId = bookDTO.Id,
                LanguageId = bookDTO.Id,
            };

            _bookDal.Add(book);

            for (int i = 0; i < bookDTO.BookPictures.Count; i++)
            {
                bookDTO.BookPictures[i].BookId = book.Id;
                _productPictureManager.AddBookPicture(productDTO.ProductPicture[i]);
            }
        }

        public List<BookDTO> GetAllProductList()
        {
            return _bookDal.GetAllBook();
        }

        public BookDTO GetProductById(int id)
        {
            return _bookDal.FindById(id);
        }

        public void RemoveProduct(AddProductDTO product, int id)
        {
            var current = _productDal.Get(x => x.Id == id);
            current.Name = product.Name;
            current.Description = product.Description;
            current.Price = product.Price;
            current.CoverPhoto = product.CoverPhoto;
            current.IsStock = product.IsStock;
            current.IsSale = product.IsSale;
            current.Brand = product.Brand;
            current.SalePrice = product.SalePrice;
            current.SKU = product.SKU;
            current.Summary = product.Summary;
            current.SecondPhoto = product.SecondPhoto;
            _productDal.Delete(current);
        }

        public void UpdateProduct(AddProductDTO product, int id)
        {
            var current = _productDal.Get(x => x.Id == id);
            current.Name = product.Name;
            current.Description = product.Description;
            current.Price = product.Price;
            current.CoverPhoto = product.CoverPhoto;
            current.IsStock = product.IsStock;
            current.IsSale = product.IsSale;
            current.Brand = product.Brand;
            current.SalePrice = product.SalePrice;
            current.SKU = product.SKU;
            current.Summary = product.Summary;
            current.SecondPhoto= product.SecondPhoto;
            _productDal.Update(current);
        }
    }
}
