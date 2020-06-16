using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Application.Contracts.Companies.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string HeadQuarters { get; set; }

        public DateTime FoundationDate { get; set; }

        public int EmployersCount { get; set; }
    }
}
