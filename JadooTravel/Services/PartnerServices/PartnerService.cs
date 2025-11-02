using AutoMapper;
using JadooTravel.Dtos.PartnerDtos;
using JadooTravel.Entities;
using JadooTravel.Settings;
using MongoDB.Driver;

namespace JadooTravel.Services.PartnerServices
{
    public class PartnerService : IPartnerService
    {
        private readonly IMongoCollection<Partner> _partnerCollection;

        private readonly IMapper _mapper;

        public PartnerService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _partnerCollection = database.GetCollection<Partner>(_databaseSettings.PartnerCollectionName);
            _mapper = mapper;
        }

        public async Task CreatePartnerAsync(CreatePartnerDto createPartnerDto)
        {
            var value = _mapper.Map<Partner>(createPartnerDto);
            await _partnerCollection.InsertOneAsync(value);
        }

        public async Task DeletePartnerAsync(string id)
        {
            await _partnerCollection.DeleteOneAsync(x => x.PartnerId == id);
        }

        public async Task<List<ResultPartnerDto>> GetAllPartnerAsync()
        {
            var values = await _partnerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultPartnerDto>>(values);
        }

        public async Task<GetPartnerByIdDto> GetPartnerByIdAsync(string id)
        {
            var value = await _partnerCollection.Find(x => x.PartnerId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetPartnerByIdDto>(value);
        }

        public async Task UpdatePartnerAsync(UpdatePartnerDto updatePartnerDto)
        {
            var value = _mapper.Map<Partner>(updatePartnerDto);
            await _partnerCollection.FindOneAndReplaceAsync(x => x.PartnerId == updatePartnerDto.PartnerId, value);
        }

        
    }
}
