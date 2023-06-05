using MyBookShopService.Data;
using MyBookShopService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookShopService.Repositories
{
	public class BookRepository
	{
		private readonly ApplicationDbContext _db;

		public BookRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public BookDTO GetCreateViewModel()
		{
			var dto = new BookDTO();
			dto.GenreList = _db.Genres.ToList();
			return dto;
		}

		public BookDTO GetEditViewModel(int id)		
		{
			var model = _db.Books.First(p => p.Id == id);
			var dto = new BookDTO
			{
				Id = model.Id,
                BookName = model.BookName,
				AuthorName = model.AuthorName,
				GenreId = model.GenreId,
				Price = model.Price
			};
			dto.GenreList = _db.Genres.ToList();
			return dto;
		}
		public List<BookDTO> GetAll() 
		{ 
			var models = _db.Books.Include(p=>p.Genre).ToList();
			var dtoList = new List<BookDTO>();
			foreach (var model in models)
			{
				var dto = new BookDTO
				{
					Id = model.Id,
					BookName = model.BookName,
					AuthorName = model.AuthorName,
					GenreId = model.GenreId,
					GenreName = model.Genre.GenreName,
					Price = model.Price
                };
				dtoList.Add(dto);
            }
			return dtoList;
		}

		public void Save(BookDTO dto)
		{

			if (dto.Id == 0)
			{
				var model = new Book
				{
					GenreId = dto.GenreId,
					BookName = dto.BookName,
					AuthorName = dto.AuthorName,
					Price = dto.Price
				};
				_db.Books.Add(model);
			}
			else
			{
				var model =_db.Books.Find(dto.Id);
				model.AuthorName = dto.AuthorName;
				model.GenreId = dto.GenreId;
				model.BookName = dto.BookName;
				model.Price = dto.Price;

				_db.Books.Update(model);
			}
			_db.SaveChanges();
		}

			
		public void Delete(int id)
		{
			var model = _db.Books.Find(id);
			_db.Books.Remove(model);
			_db.SaveChanges();
		}
	}
}
