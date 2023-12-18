using LibraryProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    internal class OpeningHourRepository
    {
        private readonly LibraryContext _libraryContext = new LibraryContext();

        public IEnumerable<OpeningHour> GetAllOpeningHours()
        {
            return _libraryContext.OpeningHours.ToList();
        }

        public void UpdateOpeningHour(OpeningHour openingHour)
        {
            var existingOpeningHour = _libraryContext.OpeningHours.Find(openingHour.Id);

            if (existingOpeningHour != null)
            {
                existingOpeningHour.Day = openingHour.Day;
                existingOpeningHour.OpeningHour1 = openingHour.OpeningHour1;
                existingOpeningHour.ClosingHour1 = openingHour.ClosingHour1;
                existingOpeningHour.OpeningHour2 = openingHour.OpeningHour2;
                existingOpeningHour.ClosingHour2 = openingHour.ClosingHour2;

                _libraryContext.SaveChanges();
            }
        }

        

    }
}

