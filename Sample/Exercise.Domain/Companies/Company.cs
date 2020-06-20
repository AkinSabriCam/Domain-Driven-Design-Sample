using Exercise.Domain.Buses;
using System;
using System.Collections.Generic;

namespace Exercise.Domain.Companies
{
    public class Company : FullAggregatedEntity<Guid>
    {
        public string CompanyName { get; private set; }
        public string HeadQuarters { get; private set; }
        public DateTime FoundationDate { get; private set; }
        public int EmployersCount { get; private set; }

        public virtual ICollection<Bus> Busses { get; set; }

        protected Company() { }

        public Company(
            string companyName,
            string headQuarters,
            DateTime foundationDate,
            int employersCount, Guid? id)
        {
            Id = id ?? Guid.NewGuid();
            CompanyName = companyName;
            HeadQuarters = headQuarters;
            FoundationDate = foundationDate;
            EmployersCount = employersCount;
        }

        public Bus AddBus(Bus bus)
        {
            if (this.Busses == null)
            {
                this.Busses = new List<Bus>();
            }
            Busses.Add(bus);
            return bus;
        }

        public void SetCompanyName(string companyName)
        {
            // you can add more bussines logic in these set methods and you can throw exception in these methods.
            if (string.IsNullOrEmpty(companyName))
            {
                CompanyName = companyName;
            }
        }

        public void SetHeadQuarters (string headQuarters)
        {
            if (string.IsNullOrEmpty(headQuarters))
            {
                HeadQuarters = headQuarters;
            }
        }

        public void SetFoundationDate (DateTime foundationDate)
        {
            if (foundationDate != null )
            {
                FoundationDate = foundationDate;
            }
        }

        public void SetEmployersCount(int employersCount)
        {
            if (employersCount >0)
            {
                EmployersCount = employersCount;
            }
        }
    }
}
