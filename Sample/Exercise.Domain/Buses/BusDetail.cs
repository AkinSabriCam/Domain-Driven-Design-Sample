using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Domain.Buses
{
    public class BusDetail
    {
        public Guid Id { get; set; }

        public Guid BusId { get; set; }

        public string Color { get; set; }

        public string Plate { get; set; }

        public DateTime ProductionDate { get; set; }

        public int Km { get; set; }

        public virtual Bus  Bus { get; set; }

        public BusDetail()
        {
            Id = Guid.NewGuid();
        }
    }
}
