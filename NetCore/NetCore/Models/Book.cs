using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace NetCore.Models
{
    public class Book
    {
        [Required]
        [MinLength(17)]
        [MaxLength(17)]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Genero Genre { get; set; }
        [Required]
        [Range(1, 99999)]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 99999)]
        public int Amount { get; set; }
        public byte[] Picture { get; set; }

        public class BookMapper
        {
            public BookMapper(EntityTypeBuilder<Book> mapper)
            {
                mapper.HasKey(b => b.ISBN);
                mapper.Property(b => b.Title).HasColumnName("Tituto");
                mapper.Property(b => b.Description).HasColumnName("Descripcion");
                mapper.Property(b => b.Genre).HasColumnName("Genero");
                mapper.Property(b => b.Price).HasColumnName("Precio").HasColumnType("decimal");
                mapper.Property(b => b.Amount).HasColumnName("Cantidad");
                mapper.Property(b => b.Picture).HasColumnName("Foto");
            }
        }
    }

    public enum Genero
    {
        Fantasy,
        Comedy,
        Drama,
        Triller
    }
}
