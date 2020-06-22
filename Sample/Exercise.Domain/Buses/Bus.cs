using System;

namespace Exercise.Domain.Buses
{
    public class Bus : FullAggregatedEntity<Guid>
    {
        public Guid CompanyId { get; private set; }

        public string Mark { get; private set; }

        public string ExpeditionNumber { get; private set; }

        public int SeatCount { get; private set; }

        public string Route { get; private set; }

        public virtual Companies.Company Company { get; private set; }

        public virtual BusDetail BusDetail { get; private set; }

        protected Bus()
        {

        }

        public Bus(string mark, string expenditionNumber, int seatCount, string route,Guid companyId, Guid? id)
        {
            Id = id ?? Guid.NewGuid();
            CompanyId = companyId;
            Mark = mark;
            ExpeditionNumber = expenditionNumber;
            SeatCount = seatCount;
            Route = route;
        }

        public void AddBusDetail(BusDetail busDetail)
        {
            if (BusDetail == null)
            {
                BusDetail = busDetail;
            }
        }

        public void SetMark(string mark)
        {
            if (!string.IsNullOrEmpty(mark))
            {
                Mark = mark;
            }
        }

        public void SetExpeditionNumber(string expeditionNumber)
        {
            // you can add more bussines logic in these set methods and you can throw exception in these methods.
            if (!string.IsNullOrEmpty(expeditionNumber))
            {
                ExpeditionNumber = expeditionNumber;
            }
        }

        public void SetSeatCount(int seatCount)
        {
            if (seatCount >= 0)
            {
                SeatCount = seatCount;
            }
        }

        public void SetRoute(string route)
        {
            if (!string.IsNullOrEmpty(route))
            {
                Route = route;
            }
        }

    }
}
