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
            CreateMap<Bus, BusDto>()
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.Company.CompanyName));

            CreateMap<Bus, BusWithDetailsDto>()
                .ForMember(x => x.Plate, opt => opt.MapFrom(x => x.BusDetail.Plate))
                .ForMember(x => x.Color, opt => opt.MapFrom(x => x.BusDetail.Color))
                .ForMember(x => x.ProductionDate, opt => opt.MapFrom(x => x.BusDetail.ProductionDate))
                .ForMember(x => x.Km, opt => opt.MapFrom(x => x.BusDetail.Km))
                .ForMember(x => x.CompanyName, opt => opt.MapFrom(x => x.Company.CompanyName));
            
            CreateMap<CreateBusDto, Bus>();

            CreateMap<AddBusDto, Bus>();

            CreateMap<UpdateBusDto, Bus>();

            CreateMap<BusWithDetailsDto, UpdateBusDto>();

            CreateMap<Company, CompanyDto>();

            CreateMap<Company, CompanyWithDetailsDto>();

            CreateMap<CreateCompanyDto, Company>();

            CreateMap<UpdateCompanyDto, Company>();

            CreateMap<CompanyWithDetailsDto, UpdateCompanyDto>();

            CreateMap<CompanyDto, UpdateCompanyDto>();

        }
    }
}
