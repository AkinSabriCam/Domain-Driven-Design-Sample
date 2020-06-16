using AutoMapper;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Application.Contracts.Companies.Dtos;
using Exercise.Domain.Buses;
using Exercise.Domain.Companies;

namespace Exercise.Application
{
    public class ExerciseAutoMapperProfile : Profile
    {
        public ExerciseAutoMapperProfile()
        {
            CreateMap<Bus, BusDto>();

            CreateMap<Bus, BusWithDetailsDto>()
                .ForMember(x => x.Plate, opt => opt.MapFrom(x => x.BusDetail.Plate))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.BusDetail.Color))
                .ForMember(x => x.ReleaseDate, opt => opt.MapFrom(x => x.BusDetail.ReleaseDate))
                .ForMember(x => x.Km, opt => opt.MapFrom(x => x.BusDetail.Km));
            

            CreateMap<CreateBusDto, Bus>();

            CreateMap<UpdateBusDto, Bus>();

            CreateMap<BusWithDetailsDto, UpdateBusDto>();


            CreateMap<Company, CompanyDto>();

            CreateMap<Company, CompanyWithDetailsDto>();

            CreateMap<CreateCompanyDto, Company>();

            CreateMap<UpdateCompanyDto, Company>();

            CreateMap<CompanyWithDetailsDto, UpdateCompanyDto>();
        }
    }
}
