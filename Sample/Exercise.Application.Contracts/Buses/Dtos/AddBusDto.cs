﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Application.Contracts.Buses.Dtos
{
    public class AddBusDto
    {
        public int SeatCount { get; set; }

        public int Km { get; set; }

        public string Mark { get; set; }

        public string ExpeditionNumber { get; set; }

        public string Route { get; set; }

        public string Color { get; set; }

        public string Plate { get; set; }

        public DateTime ProductionDate { get; set; }
    }
}
