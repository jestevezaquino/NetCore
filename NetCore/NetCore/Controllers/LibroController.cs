using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NetCore.Models;
using NetCore.Services;

namespace NetCore.Controllers
{
    public class LibroController : Controller
    {

        private readonly BookCrud BC;

        public LibroController(BookCrud _BC)
        {
            BC = _BC;
        }

        public async Task<IActionResult> ShowBooks()
        {
            var result = await BC.GetBooks(); 
            return View(result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book book, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                if(picture != null)
                {

                    using (var ms = new MemoryStream())
                    {
                        picture.CopyTo(ms);
                        book.Picture = ms.ToArray();
                    }

                    var resultado = BC.AddBook(book);

                    if (resultado)
                    {
                        ModelState.Clear();
                    }

                    ViewBag.Resultado = resultado;
                    return View();
                }

                ViewBag.PictureError = "You have to choose a photo for the book.";
                return View(book);
            }

            if (picture == null)
            {
                ViewBag.PictureError = "You have to choose a photo for the book.";
            }

            return View(book);
        }

        [HttpGet("Libro/Edit/{ISBN}")]
        public IActionResult Edit(string ISBN)
        {
            var libro = BC.GetBookByISBN(ISBN);
            return View(libro);

        }

        [HttpPost]
        public IActionResult Edit(Book book, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        picture.CopyTo(ms);
                        book.Picture = ms.ToArray();
                    }

                    var resultado = BC.EditBook(book);

                    if (resultado)
                    {
                        ModelState.Clear();
                    }

                    ViewBag.Resultado = resultado;
                    return View();
                }

                ViewBag.PictureError = "You have to choose a photo for the book.";
                return View(book);
            }

            if (picture == null)
            {
                ViewBag.PictureError = "You have to choose a photo for the book.";
            }

            return View(book);
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
