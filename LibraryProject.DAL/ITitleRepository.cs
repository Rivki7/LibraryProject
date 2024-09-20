
using LibraryProjectRepository.Models;

namespace LibraryProjectRepository
{
    public interface ITitleRepository
    {
        Task<Title> AddTitle(Title title);
        Task<bool> DeleteTitle(int id);
        Task<List<Title>> GetAllTitles();
        Task<Title> GetTitleById(int id);
        Task<List<Title>> GetTitlesByAuthor(string author);
        Task<List<Title>> GetTitlesByCategories(List<string> categoryNames);
        Task<List<Title>> GetTitlesByCategory(string categoryName);
        Task<List<Title>> GetTitlesEnteredWithinLast60Days();
        Task<Title> UpdateTitle(Title updatedTitle); 
    }
}