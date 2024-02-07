﻿using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category newCategory);
        Task<List<Category>> GetAllCategories();
    }
}