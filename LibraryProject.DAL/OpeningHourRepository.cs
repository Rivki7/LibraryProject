using LibraryProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class OpeningHourRepository : IOpeningHourRepository
    {
        private readonly LibraryContext _libraryContext;

        public OpeningHourRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<OpeningHour>> GetAllOpeningHours()
        {
            try
            {
                List < OpeningHour > openingHours= await _libraryContext.OpeningHours.ToListAsync();
               if(openingHours != null ) {
                    return openingHours; 
                }
                throw new Exception("Opening Hours not found!"); 
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in Opening Hours Repository");

                return null;
            }
        }

        public async Task<OpeningHour> UpdateOpeningHour(OpeningHour openingHour)
        {
            try
            {
                var existingOpeningHour = await _libraryContext.OpeningHours.FindAsync(openingHour.Id);

                if (existingOpeningHour != null)
                {
                    existingOpeningHour.Day = openingHour.Day;
                    existingOpeningHour.OpeningHour1 = openingHour.OpeningHour1;
                    existingOpeningHour.ClosingHour1 = openingHour.ClosingHour1;
                    existingOpeningHour.OpeningHour2 = openingHour.OpeningHour2;
                    existingOpeningHour.ClosingHour2 = openingHour.ClosingHour2;

                    _libraryContext.SaveChangesAsync();
                }
                return await _libraryContext.OpeningHours.FindAsync(openingHour.Id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }




    }
}

