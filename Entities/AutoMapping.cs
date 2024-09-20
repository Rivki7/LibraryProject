using AutoMapper;
using Entities.DTO;
using LibraryProjectRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<BooksArchive, BooksArchiveDTO>();
            CreateMap<BooksArchiveDTO, BooksArchive>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<CategoryToTitle, CategoryToTitleDTO>();
            CreateMap<CategoryToTitleDTO, CategoryToTitle>();
            CreateMap<CheckedBook, CheckedBookDTO>();
            CreateMap<CheckedBookDTO, CheckedBook>();
            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();
           
            CreateMap<Message, MessageDTO>();
            CreateMap<MessageDTO, Message>();
            CreateMap<OpeningHour, OpeningHourDTO>();
            CreateMap<OpeningHourDTO, OpeningHour>();
            CreateMap<Title, TitleDTO>();
            CreateMap<TitleDTO, Title>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UsersLevelDTO, UsersLevel>();
            CreateMap< UsersLevel, UsersLevelDTO>();
        }
    }
}
