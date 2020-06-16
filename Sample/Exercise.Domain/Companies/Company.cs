using Exercise.Domain.Buses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise.Domain.Companies
{
    public class Company : FullAggregatedEntity<Guid>
    {
        public string CompanyName { get; set; }
        public string HeadQuarters { get; set; }
        public DateTime FoundationDate { get; set; }
        public int EmployersCount { get; set; }

        public virtual ICollection<Bus> Busses { get; set; }

        public Bus AddBus(Bus bus)
        {
            if (this.Busses == null)
            {
                this.Busses = new List<Bus>();
            }
            Busses.Add(bus);
            return bus;
        }
    }
}
