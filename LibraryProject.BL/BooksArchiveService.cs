using AutoMapper;
using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class BooksArchiveService : IBooksArchiveService
    {
        private readonly IBooksArchiveRepository _booksArchiveRepository;
        private readonly IMapper _mapper;


        public BooksArchiveService(IBooksArchiveRepository booksArchiveRepository, IMapper mapper)
        {
            _booksArchiveRepository = booksArchiveRepository;
            _mapper = mapper;
        }

        public async Task<BooksArchiveDTO> AddBooksArchive(BooksArchiveDTO booksArchiveDTO)
        {
            try
            {
                var booksArchive = _mapper.Map<BooksArchive>(booksArchiveDTO);
                var addedBooksArchive = await _booksArchiveRepository.AddBooksArchive(booksArchive);
                return _mapper.Map<BooksArchiveDTO>(addedBooksArchive);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync("Problem in service layer- AddBooksArchive");
                return null;
            }
        }

        public async Task<List<BooksArchiveDTO>> GetAllBooksArchive()
        {
            try
            {
                var booksArchives = await _booksArchiveRepository.GetAllBooksArchive();
                return _mapper.Map<List<BooksArchiveDTO>>(booksArchives);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Failed to retrieve BooksArchives.", ex);
                return null;
            }
        }

        public async Task<BooksArchiveDTO> GetBooksArchiveById(int id)
        {
            try
            {
                var booksArchive = await _booksArchiveRepository.GetByIdBooksArchive(id);
                return _mapper.Map<BooksArchiveDTO>(booksArchive);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to retrieve BooksArchive with id {id}.", ex);
                return null;
            }
        }
    }
}
