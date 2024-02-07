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
    public class TitleService : ITitleService
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;

        public TitleService(IMapper mapper, ITitleRepository titleRepository)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
        }

        public async Task<TitleDTO> AddTitle(TitleDTO titleDTO)
        {
            try
            {
                Title title = _mapper.Map<Title>(titleDTO);
                title = await _titleRepository.AddTitle(title);
                return _mapper.Map<TitleDTO>(title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddTitle: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteTitle(int id)
        {
            try
            {
                return await _titleRepository.DeleteTitle(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteTitle: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TitleDTO>> GetAllTitles()
        {
            try
            {
                var titles = await _titleRepository.GetAllTitles();
                return _mapper.Map<List<TitleDTO>>(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllTitles: {ex.Message}");
                throw;
            }
        }

        public async Task<TitleDTO> GetTitleById(int id)
        {
            try
            {
                var title = await _titleRepository.GetTitleById(id);
                return _mapper.Map<TitleDTO>(title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitleById: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TitleDTO>> GetTitlesByAuthor(string author)
        {
            try
            {
                var titles = await _titleRepository.GetTitlesByAuthor(author);
                return _mapper.Map<List<TitleDTO>>(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesByAuthor: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TitleDTO>> GetTitlesByCategories(List<string> categoryNames)
        {
            try
            {
                var titles = await _titleRepository.GetTitlesByCategories(categoryNames);
                return _mapper.Map<List<TitleDTO>>(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesByCategories: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TitleDTO>> GetTitlesByCategory(string categoryName)
        {
            try
            {
                var titles = await _titleRepository.GetTitlesByCategory(categoryName);
                return _mapper.Map<List<TitleDTO>>(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesByCategory: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TitleDTO>> GetTitlesEnteredWithinLast60Days()
        {
            try
            {
                var titles = await _titleRepository.GetTitlesEnteredWithinLast60Days();
                return _mapper.Map<List<TitleDTO>>(titles);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTitlesEnteredWithinLast60Days: {ex.Message}");
                throw;
            }
        }

      
        public async Task<TitleDTO> UpdateTitle(TitleDTO updatedTitleDTO)
        {
            try
            {
                
                var updatedTitle = _mapper.Map<Title>(updatedTitleDTO);
               

                var result = await _titleRepository.UpdateTitle(updatedTitle);

                if (result == null)
                    return null;

               
                var updatedTitleDto = _mapper.Map<TitleDTO>(result);
                return updatedTitleDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateTitle: {ex.Message}");
                throw;
            }
        }

    }
}
