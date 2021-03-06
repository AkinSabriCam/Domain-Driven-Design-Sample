﻿using AutoMapper;
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

            CreateMap<BusWithDetailsDto, UpdateBusViewModel>();

            CreateMap<UpdateBusViewModel, UpdateBusDto>();

            CreateMap<CreateCompanyViewModel, CreateCompanyDto>();

            CreateMap<CompanyDto, UpdateCompanyViewModel>();

            CreateMap<UpdateCompanyViewModel, UpdateCompanyDto>();
        }
    }
}
