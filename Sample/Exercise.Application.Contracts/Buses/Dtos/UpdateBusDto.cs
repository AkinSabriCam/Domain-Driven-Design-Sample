using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Application.Contracts.Buses.Dtos
{
    public class UpdateBusDto : CreateUpdateBusDto
    {
        public Guid Id { get; set; }
    }
}
