using System;

namespace Exercise.Application.Contracts.Buses.Dtos
{
    public class GetListInput
    {
        public Guid? CompanyId;

        public string Filter;
    }
}
