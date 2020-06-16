using AutoMapper;
using Exercise.Application.Contracts.Buses.Dtos;
using Exercise.Application.Contracts.Companies.Dtos;
using Exercise.Web.Pages.Buses;
using Exercise.Web.Pages.Companies;

namespace Exercise.Web
{
    public class ExerciseWebAutoMapperProfile : Profile
    {
        public ExerciseWebAutoMapperProfile()
        {
            CreateMap<CreateBusViewModel, CreateBusDto>();

            CreateMap<CreateCompanyViewModel, CreateCompanyDto>();
        }
    }
}
