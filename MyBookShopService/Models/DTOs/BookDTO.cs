using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookShopService.Models
{
    public class BookDTO
    {
        public int Id { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Kategori alanı zorunludur.")]

        public int GenreId { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string BookName { get; set; }

        [DisplayName("Yazar")]
        [Required(ErrorMessage = "Yazar alanı zorunludur.")]
        public string AuthorName { get; set; }

		[DisplayName("Fiyat")]
		[Required(ErrorMessage = "Fiyat alanı zorunludur.")]
        public double Price { get; set; }
		public string? GenreName { get; set; }
        
        public List<Genre>? GenreList { get; set; }
    }
}
