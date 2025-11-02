using JadooTravel.Dtos.PartnerDtos;

namespace JadooTravel.Services.PartnerServices
{
    public interface IPartnerService
    {
        Task<List<ResultPartnerDto>> GetAllPartnerAsync();
        Task CreatePartnerAsync(CreatePartnerDto createPartnerDto);
        Task UpdatePartnerAsync(UpdatePartnerDto updatePartnerDto);
        Task DeletePartnerAsync(string id);
        Task<GetPartnerByIdDto> GetPartnerByIdAsync(string id);

        
    }
}
