using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Application.Contracts.Companies.Dtos
{
    public class UpdateCompanyDto : CreateUpdateCompanyDto
    {
        public Guid Id { get; set; }
    }
}
