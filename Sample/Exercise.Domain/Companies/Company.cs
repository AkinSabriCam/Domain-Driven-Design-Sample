using Exercise.Domain.Buses;
using System;
using System.Collections.Generic;

namespace Exercise.Domain.Companies
{
    public class Company :FullAggregatedEntity<Guid>
    {
        public string CompanyName { get; set; }
        public string HeadQuarters { get; set; }
        public DateTime FoundationDate { get; set; }
        public int EmployersCount { get; set; }

        public virtual ICollection<Bus> Busses { get; set; }
    
        public void AddBus(Bus bus)
        {
            Busses.Add(bus);
        }
    }
}
