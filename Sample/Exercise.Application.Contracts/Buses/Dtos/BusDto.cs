using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Application.Contracts.Buses.Dtos
{
    public class BusDto
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public int SeatCount { get; set; }

        public string Mark { get; set; }

        public string ExpeditionNumber { get; set; }

        public string Route { get; set; }

        
    }
}
