using System;

namespace Exercise.Domain.Buses
{
    public class Bus : FullAggregatedEntity<Guid>
    {
        public Guid CompanyId { get; set; }

        public string Mark { get; set; }

        public string ExpeditionNumber { get; set; }

        public int SeatCount { get; set; }

        public string Route { get; set; }

        public virtual Companies.Company Company { get; set; }

        public virtual BusDetail BusDetail { get; set; }

        public Bus()
        {
            Id = Guid.NewGuid();
        }

        public Bus(string mark, string expenditionNumber, int seatCount, string route)
        {
            CompanyId = Guid.NewGuid();
            Mark = mark;
            ExpeditionNumber = expenditionNumber;
            SeatCount = seatCount;
            Route = route;
        }

        public void AddBusDetail(BusDetail busDetail)
        {
            this.BusDetail = busDetail;
        }

    }
}
