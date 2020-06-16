using Exercise.Application.Contracts.Buses.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Application.Contracts.Companies.Dtos
{
    public class CompanyWithDetailsDto
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string HeadQuarters { get; set; }

        public DateTime FoundationDate { get; set; }

        public int EmployersCount { get; set; }

        public IList<BusDto> Buses { get; set; }
    }
}
