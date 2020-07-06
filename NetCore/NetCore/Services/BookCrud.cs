using Microsoft.EntityFrameworkCore;
using NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Services
{
    public class BookCrud
    {
        private readonly ApplicationDbContext DB;

        public BookCrud(ApplicationDbContext _DB)
        {
            DB = _DB;
        }

        public async Task<List<Book>> GetBooks()
        {
            var libros = await DB.Libros.ToListAsync();
            return libros;
        }

        public Book GetBookByISBN(string ISBN)
        {
            var libro = DB.Libros.Where(li => li.ISBN == ISBN).FirstOrDefault();
            return libro;
        }

        public bool AddBook(Book book)
        {
            try
            {
                DB.Libros.Add(book);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditBook(Book book)
        {
            try
            {
                var libro = DB.Libros.Where(li => li.ISBN == book.ISBN).FirstOrDefault();
                libro.Title = book.Title;
                libro.Description = book.Description;
                libro.Genre = book.Genre;
                libro.Price = book.Price;
                libro.Amount = book.Amount;
                libro.Picture = book.Picture;
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
