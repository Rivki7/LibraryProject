using Entities.DTO;

namespace LibraryProjectService
{
    public interface ITitleService
    {
        Task<TitleDTO> AddTitle(TitleDTO titleDTO);
        Task<bool> DeleteTitle(int id);
        Task<List<TitleDTO>> GetAllTitles();
        Task<TitleDTO> GetTitleById(int id);
        Task<List<TitleDTO>> GetTitlesByAuthor(string author);
        Task<List<TitleDTO>> GetTitlesByCategories(List<string> categoryNames);
        Task<List<TitleDTO>> GetTitlesByCategory(string categoryName);
        Task<List<TitleDTO>> GetTitlesEnteredWithinLast60Days();
        Task<TitleDTO> UpdateTitle(TitleDTO updatedTitleDTO);
    }
}