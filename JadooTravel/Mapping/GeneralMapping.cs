using AutoMapper;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Dtos.PartnerDtos;
using JadooTravel.Dtos.ReservationDtos;
using JadooTravel.Dtos.TestimonialDtos;
using JadooTravel.Entities;

namespace JadooTravel.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryByldDto>().ReverseMap();

            CreateMap<Destination,ResultDestinationDto>().ReverseMap();
            CreateMap<Destination, CreateDestinationDto>().ReverseMap();
            CreateMap<Destination, UpdateDestinationDto>().ReverseMap();
            CreateMap<Destination, GetDestinationByIdDto>().ReverseMap();

            CreateMap<Partner, ResultPartnerDto>().ReverseMap();
            CreateMap<Partner, CreatePartnerDto>().ReverseMap();
            CreateMap<Partner, UpdatePartnerDto>().ReverseMap();
            CreateMap<Partner, GetPartnerByIdDto>().ReverseMap();

            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();



        }
    }
}
