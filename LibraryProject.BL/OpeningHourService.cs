using AutoMapper;
using Entities.DTO;
using LibraryProjectRepository;
using LibraryProjectRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class OpeningHourService : IOpeningHourService
    {
        private IMapper _mapper;
        private IOpeningHourRepository _openingHourRepository;

        public OpeningHourService(IMapper mapper, IOpeningHourRepository openingHourRepository)
        {
            _mapper = mapper;
            _openingHourRepository = openingHourRepository;
        }


        public async Task<List<OpeningHourDTO>> GetAllOpeningHours()
        {
            try
            {
                List<OpeningHour> openingHours = await _openingHourRepository.GetAllOpeningHours();
                if (openingHours != null)
                {
                    List<OpeningHourDTO> openingHourDTOs = _mapper.Map<List<OpeningHourDTO>>(openingHours);
                    return openingHourDTOs;
                }
                throw new Exception("No opening hours found"); 
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in OpeningHours service"); 
                return null;
            }
        }

        public async Task<OpeningHourDTO> UpdateOpeningHour(OpeningHourDTO updatedOpeningHourDTO)
        {
            try
            {
                OpeningHour updatedOpeningHour = _mapper.Map<OpeningHour>(updatedOpeningHourDTO);

                var existingOpeningHour = await _openingHourRepository.UpdateOpeningHour(updatedOpeningHour);

                if (existingOpeningHour != null)
                {

                    OpeningHourDTO resultOpeningHourDTO = _mapper.Map<OpeningHourDTO>(existingOpeningHour);
                    return resultOpeningHourDTO;
                }

               throw new Exception("No opening hours found!");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + "Error in event Repository");
                return null;
            }
        }


    }
}
