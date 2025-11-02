using JadooTravel.Dtos.ReservationDtos;

namespace JadooTravel.Services.ReservationServices
{
    public interface IReservationService
    {
        Task<List<ResultReservationDto>> GetAllReservationAsync();

        Task CreateReservationAsync(CreateReservationDto createReservationDto);
        Task UpdateReservationAsync(UpdateReservationDto updateReservationDto);
        Task DeleteReservationAsync(string id);
        Task<GetReservationByIdDto> GetReservationByIdAsync(string id);
    }
}
